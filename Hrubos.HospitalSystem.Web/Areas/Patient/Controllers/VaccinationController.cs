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
    public class VaccinationController : Controller
    {
        private readonly IVaccinationAppService _vaccinationAppService;
        private readonly IVaccineTypeAppService _vaccineTypeAppService;
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ILogger<VaccinationController> _logger;

        public VaccinationController(IVaccinationAppService vaccinationAppService, IVaccineTypeAppService vaccineTypeAppService, ISecurityIdentityService securityIdentityService, ILogger<VaccinationController> logger)
        {
            _vaccinationAppService = vaccinationAppService;
            _vaccineTypeAppService = vaccineTypeAppService;
            _securityIdentityService = securityIdentityService;
            _logger = logger;
        }

        public async Task<IActionResult> Select()
        {
            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User);
            _logger.LogInformation("Pacient s ID {id} zobrazil svá očkování.", currentUser.Id);

            var allVaccinations = _vaccinationAppService.SelectAll();

            var myVaccinations = allVaccinations
                .Where(v => v.PatientId == currentUser.Id)
                .OrderByDescending(v => v.DateTime)
                .ToList();

            return View(myVaccinations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetVaccineTypeSelectList();

            var model = new Vaccination
            {
                DateTime = DateTime.Now.AddDays(2).Date // defaultně za 2 dny
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vaccination vaccination)
        {
            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User);

            vaccination.PatientId = currentUser.Id;

            // Kontrola, zda je datum očkování minimálně za 2 dny
            if (vaccination.DateTime < DateTime.Now.Date.AddDays(2))
            {
                ModelState.AddModelError(nameof(Vaccination.DateTime), "Objednat se musíte minimálně 2 dny předem.");
            }

            ModelState.Remove(nameof(Vaccination.Patient));

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Pacient s ID {id}: Vytvoření očkování selhalo kvůli validaci.", currentUser.Id);
                SetVaccineTypeSelectList(vaccination.VaccineTypeId);
                return View(vaccination);
            }

            try
            {
                _vaccinationAppService.Create(vaccination);
                _logger.LogInformation("Pacient s ID {patId} se objednal na očkování na {date}.", currentUser.Id, vaccination.DateTime);

                return RedirectToAction(nameof(Select));
            }
            catch (InvalidOperationException ex) // Kapacita naplněna
            {
                ModelState.AddModelError(nameof(Vaccination.DateTime), ex.Message);
                SetVaccineTypeSelectList(vaccination.VaccineTypeId);
                return View(vaccination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření očkování pacientem.");
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vaccination = _vaccinationAppService.GetById(id);
            if (vaccination == null) return NotFound();

            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User);

            if (vaccination.PatientId != currentUser.Id)
            {
                _logger.LogWarning("Pacient s ID {patId} se pokusil zrušit cizí očkování {vacId}.", currentUser.Id, id);
                return NotFound();
            }

            // Nelze zrušit již proběhlé očkování
            if (vaccination.DateTime < DateTime.Now)
            {
                _logger.LogWarning("Pacient s ID {patId} se pokusil zrušit již proběhlé očkování s ID {examId}.", currentUser.Id, id);
                return RedirectToAction(nameof(Select));
            }

            _vaccinationAppService.Delete(id);
            _logger.LogInformation("Pacient s ID {patId} zrušil své očkování s ID {vacId}.", currentUser.Id, id);

            return RedirectToAction(nameof(Select));
        }

        void SetVaccineTypeSelectList(int? vaccineTypeId = null)
        {
            var vaccineTypes = _vaccineTypeAppService.SelectAll();

            var selectItems = vaccineTypes.Select(e => new
            {
                Id = e.Id,
                DisplayText = e.Name
            });

            ViewBag.VaccineTypesList = new SelectList(selectItems, "Id", "DisplayText", vaccineTypeId);
        }
    }
}