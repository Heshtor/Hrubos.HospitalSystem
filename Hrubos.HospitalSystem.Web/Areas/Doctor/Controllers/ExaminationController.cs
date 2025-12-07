using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hrubos.HospitalSystem.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = nameof(Roles.Doctor))]
    public class ExaminationController : Controller
    {
        private readonly IExaminationAppService _examinationAppService;
        private readonly IExaminationTypeAppService _examinationTypeAppService;
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ILogger<ExaminationController> _logger;

        public ExaminationController(IExaminationAppService examinationAppService, IExaminationTypeAppService examinationTypeAppService, ISecurityIdentityService securityIdentityService, ILogger<ExaminationController> logger)
        {
            _examinationAppService = examinationAppService;
            _examinationTypeAppService = examinationTypeAppService;
            _securityIdentityService = securityIdentityService;
            _logger = logger;
        }

        public async Task<IActionResult> Select(int patientId)
        {
            _logger.LogInformation("Doktor zobrazil seznam vyšetření pacienta s ID {id}.", patientId);

            var currentDoctor = await _securityIdentityService.GetCurrentUserAsync(User); // aktuálně přihlášený doktor

            ViewBag.CurrentDoctorId = currentDoctor.Id;

            var allExaminations = _examinationAppService.SelectAll(); // všechna vyšetření pacientů

            // Vyšetření konkrétního pacienta
            var patientExaminations = allExaminations
                .Where(e => e.PatientId == patientId)
                .OrderByDescending(e => e.DateTime) // seřazení od nejnovějšího vyšetření
                .ToList();


            var patient = patientExaminations.FirstOrDefault()?.Patient;
            if (patient != null)
            {
                ViewBag.PatientName = $"{patient.FirstName} {patient.LastName} ({patient.UserName})";
            }

            return View(patientExaminations);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var examination = _examinationAppService.GetById(id);
            if (examination == null) return NotFound();

            var currentDoctor = await _securityIdentityService.GetCurrentUserAsync(User); // aktuálně přihlášený doktor

            // Kontrola, zda vyšetření patří aktuálnímu doktorovi
            if (examination.DoctorId != currentDoctor.Id)
            {
                _logger.LogWarning("Doktor s ID {docId} se pokusil smazat vyšetření s ID {examId} cizího doktora.", currentDoctor.Id, id);

                Response.StatusCode = 403;
                return View("~/Areas/Account/Views/Home/AccessDenied.cshtml");
            }

            _examinationAppService.Delete(id);

            return RedirectToAction(nameof(Select), new { patientId = examination.PatientId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var examination = _examinationAppService.GetById(id);
            if (examination == null) return NotFound();

            examination.Patient = await _securityIdentityService.GetUserByIdAsync(examination.PatientId.ToString());

            var currentDoctor = await _securityIdentityService.GetCurrentUserAsync(User); // aktuálně přihlášený doktor

            // Kontrola, zda vyšetření patří aktuálnímu doktorovi
            if (examination.DoctorId != currentDoctor.Id)
            {
                _logger.LogWarning("Doktor s ID {docId} se pokusil editovat vyšetření s ID {examId} cizího doktora.", currentDoctor.Id, id);

                Response.StatusCode = 403;
                return View("~/Areas/Account/Views/Home/AccessDenied.cshtml");
            }

            SetExaminationTypeSelectList(examination.ExaminationTypeId);
            return View(examination);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Examination examination)
        {
            // Ověření, zda vyšetření patří aktuálnímu doktorovi
            var originalExamination = _examinationAppService.GetById(id);
            var currentDoctor = await _securityIdentityService.GetCurrentUserAsync(User);

            if (originalExamination == null) return NotFound();
            if (originalExamination.DoctorId != currentDoctor.Id)
            {
                _logger.LogWarning("Doktor s ID {docId} se pokusil editovat vyšetření s ID {examId} cizího doktora.", currentDoctor.Id, id);

                Response.StatusCode = 403;
                return View("~/Areas/Account/Views/Home/AccessDenied.cshtml");
            }

            // Nemění PatientID ani DoctorId
            examination.PatientId = originalExamination.PatientId;
            examination.DoctorId = currentDoctor.Id;

            ModelState.Remove(nameof(Examination.Doctor));
            ModelState.Remove(nameof(Examination.Patient));

            // Kontrola, zda se nemění datum vyšetření
            if (originalExamination.DateTime.Date != examination.DateTime.Date)
            {
                ModelState.AddModelError(nameof(Examination.DateTime), $"Nemůžete změnit datum vyšetření (původní: {originalExamination.DateTime.ToShortDateString()}), pouze čas.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace vyšetření s ID {id} selhala kvůli validaci.", id);

                SetExaminationTypeSelectList(examination.ExaminationTypeId);

                return View(examination);
            }

            try
            {
                _examinationAppService.Edit(id, examination);
                _logger.LogInformation("Editace vyšetření s ID {id} proběhla úspěšně.", id);
                return RedirectToAction(nameof(Select), new { patientId = examination.PatientId });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "Chyba při editaci vyšetření.");

                ModelState.AddModelError(nameof(Examination.DateTime), ex.Message);
                SetExaminationTypeSelectList(examination.ExaminationTypeId);

                return View(examination);
            }
        }

        void SetExaminationTypeSelectList(int? examinationTypeId = null)
        {
            var examinationTypes = _examinationTypeAppService.SelectAll();

            var selectItems = examinationTypes.Select(e => new
            {
                Id = e.Id,
                DisplayText = $"{e.Name}"
            });

            ViewBag.ExaminationTypesList = new SelectList(selectItems, "Id", "DisplayText", examinationTypeId);
        }
    }
}
