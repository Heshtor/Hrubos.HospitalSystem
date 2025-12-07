using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hrubos.HospitalSystem.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    [Authorize(Roles = nameof(Roles.Patient))]
    public class ExaminationController : Controller
    {
        private readonly IExaminationAppService _examinationAppService;
        private readonly IExaminationTypeAppService _examinationTypeAppService;
        private readonly IDoctorPatientAppService _doctorPatientAppService;
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ILogger<ExaminationController> _logger;

        public ExaminationController(IExaminationAppService examinationAppService, IExaminationTypeAppService examinationTypeAppService, IDoctorPatientAppService doctorPatientAppService, ISecurityIdentityService securityIdentityService, ILogger<ExaminationController> logger)
        {
            _examinationAppService = examinationAppService;
            _examinationTypeAppService = examinationTypeAppService;
            _doctorPatientAppService = doctorPatientAppService;
            _securityIdentityService = securityIdentityService;
            _logger = logger;
        }

        public async Task<IActionResult> Select()
        {
            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User);
            _logger.LogInformation("Pacient s ID {id} zobrazil svá vyšetření.", currentUser.Id);

            var allExaminations = _examinationAppService.SelectAll();

            var myExaminations = allExaminations
                .Where(e => e.PatientId == currentUser.Id)
                .OrderByDescending(e => e.DateTime)
                .ToList();

            return View(myExaminations);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User);

            SetExaminationTypeSelectList();
            await SetMyDoctorsSelectList(currentUser.Id);

            var model = new Examination
            {
                DateTime = DateTime.Now.AddDays(2).Date // defaultně za 2 dny
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Examination examination)
        {
            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User);

            examination.PatientId = currentUser.Id;

            // Kontrola, zda je datum vyšetření minimálně za 2 dny
            if (examination.DateTime < DateTime.Now.Date.AddDays(2))
            {
                ModelState.AddModelError(nameof(Examination.DateTime), "Objednat se musíte minimálně 2 dny předem.");
            }

            // Kontrola, zda vazba doctor-patient existuje
            var myRelations = _doctorPatientAppService.SelectAll()
                .Where(dp => dp.PatientId == currentUser.Id)
                .Select(dp => dp.DoctorId)
                .ToList();

            if (!examination.DoctorId.HasValue || !myRelations.Contains(examination.DoctorId.Value))
            {
                ModelState.AddModelError(nameof(Examination.DoctorId), "Můžete se objednat pouze ke svému ošetřujícímu lékaři.");
            }

            ModelState.Remove(nameof(Examination.Patient));
            ModelState.Remove(nameof(Examination.Doctor));

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Pacient s ID {id}: Vytvoření vyšetření selhalo kvůli validaci.", currentUser.Id);
                SetExaminationTypeSelectList(examination.ExaminationTypeId);
                await SetMyDoctorsSelectList(currentUser.Id, examination.DoctorId);
                return View(examination);
            }

            try
            {
                _examinationAppService.Create(examination);
                _logger.LogInformation("Pacient s ID {patId} se objednal na vyšetření k doktorovi s ID {docId} na {date}.", currentUser.Id, examination.DoctorId, examination.DateTime);

                return RedirectToAction(nameof(Select));
            }
            catch (InvalidOperationException ex) // Kapacita naplněna
            {
                ModelState.AddModelError(nameof(Examination.DateTime), ex.Message);

                SetExaminationTypeSelectList(examination.ExaminationTypeId);
                await SetMyDoctorsSelectList(currentUser.Id, examination.DoctorId);

                return View(examination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření vyšetření pacientem.");
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var examination = _examinationAppService.GetById(id);
            if (examination == null) return NotFound();

            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User);

            if (examination.PatientId != currentUser.Id)
            {
                _logger.LogWarning("Pacient s ID {patId} se pokusil zrušit cizí vyšetření s ID {examId}.", currentUser.Id, id);
                return NotFound();
            }

            // Nelze zrušit již proběhlé vyšetření
            if (examination.DateTime < DateTime.Now)
            {
                _logger.LogWarning("Pacient s ID {patId} se pokusil zrušit již proběhlé vyšetření s ID {examId}.", currentUser.Id, id);
                return RedirectToAction(nameof(Select)); 
            }

            _examinationAppService.Delete(id);
            _logger.LogInformation("Pacient s ID {patId} zrušil své vyšetření s ID {examId}.", currentUser.Id, id);

            return RedirectToAction(nameof(Select));
        }

        void SetExaminationTypeSelectList(int? examinationTypeId = null)
        {
            var examinationTypes = _examinationTypeAppService.SelectAll();

            var selectItems = examinationTypes.Select(e => new
            {
                Id = e.Id,
                DisplayText = e.Name
            });

            ViewBag.ExaminationTypesList = new SelectList(selectItems, "Id", "DisplayText", examinationTypeId);
        }

        async Task SetMyDoctorsSelectList(int patientId, int? selectedDoctorId = null)
        {
            var allRelations = _doctorPatientAppService.SelectAll();

            // Pouze ID doktorů daného pacienta
            var myDoctorIds = allRelations
                .Where(dp => dp.PatientId == patientId)
                .Select(dp => dp.DoctorId)
                .ToList();

            var allUsers = await _securityIdentityService.GetAllUsersAsync();

            var myDoctors = allUsers
                .Where(u => myDoctorIds.Contains(u.Id))
                .Select(u => new
                {
                    Id = u.Id,
                    DisplayText = $"{u.FirstName} {u.LastName} ({u.UserName})"
                })
                .ToList();

            ViewBag.DoctorsList = new SelectList(myDoctors, "Id", "DisplayText", selectedDoctorId);
        }
    }
}
