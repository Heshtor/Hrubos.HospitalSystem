using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
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

        public IActionResult Select()
        {
            _logger.LogInformation("Uživatel zobrazil seznam vakcinací.");
            var vaccinations = _vaccinationAppService.SelectAll();
            return View(vaccinations);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SetVaccineTypeSelectList();
            await SetPatientSelectList();

            return View(new Vaccination());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vaccination vaccination)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Vytvoření vakcinace selhalo kvůli validaci.");

                SetVaccineTypeSelectList(vaccination.VaccineTypeId);
                await SetPatientSelectList(vaccination.PatientId);

                return View(vaccination);
            }

            try
            {
                _vaccinationAppService.Create(vaccination);
                _logger.LogInformation("Vytvořena nová vakcinace s ID {id}.", vaccination.Id);
                return RedirectToAction(nameof(Select));
            }
            catch (InvalidOperationException ex) // již naplněná kapacita
            {
                ModelState.AddModelError(nameof(Vaccination.DateTime), ex.Message);

                _logger.LogWarning(ex, "Pokus o vytvoření vakcinace nad denní limit.");

                SetVaccineTypeSelectList(vaccination.VaccineTypeId);
                await SetPatientSelectList(vaccination.PatientId);

                return View(vaccination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření vakcinace.");
                return View("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _vaccinationAppService.Delete(id);

            if (deleted)
            {
                _logger.LogInformation("Smazána vakcinace s ID {id}.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o smazání neexistující vakcinace s ID {id}.", id);
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vaccination = _vaccinationAppService.GetById(id);

            if (vaccination == null)
            {
                return NotFound();
            }

            SetVaccineTypeSelectList(vaccination.VaccineTypeId);
            await SetPatientSelectList(vaccination.PatientId);

            return View(vaccination);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Vaccination vaccination)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace vakcinace s ID {id} selhala kvůli validaci.", id);

                SetVaccineTypeSelectList(vaccination.VaccineTypeId);
                await SetPatientSelectList(vaccination.PatientId);

                return View(vaccination);
            }

            try
            {
                bool updated = _vaccinationAppService.Edit(id, vaccination);

                if (updated)
                {
                    _logger.LogInformation("Editace vakcinace s ID {id} proběhla úspěšně.", id);
                    return RedirectToAction(nameof(Select));
                }
                else
                {
                    _logger.LogWarning("Pokus o editaci neexistující vakcinace s ID {id}.", id);
                    return NotFound();
                }
            }
            catch (InvalidOperationException ex) // již naplněná kapacita
            {
                ModelState.AddModelError(nameof(Vaccination.DateTime), ex.Message);

                _logger.LogWarning(ex, "Pokus o editaci vakcinace nad denní limit.");

                SetVaccineTypeSelectList(vaccination.VaccineTypeId);
                await SetPatientSelectList(vaccination.PatientId);

                return View(vaccination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při editaci vakcinace.");
                return View("Error");
            }
        }

        void SetVaccineTypeSelectList(int? vaccineTypeId = null)
        {
            var vaccineTypes = _vaccineTypeAppService.SelectAll();

            var selectItems = vaccineTypes.Select(e => new
            {
                Id = e.Id,
                DisplayText = $"[{e.Id}] {e.Name}"
            });

            ViewBag.VaccineTypesList = new SelectList(selectItems, "Id", "DisplayText", vaccineTypeId);
        }

        async Task SetPatientSelectList(int? userId = null)
        {
            var allUsers = await _securityIdentityService.GetAllUsersAsync();

            var patientsOnly = new List<User>();
            foreach (var user in allUsers)
            {
                var roles = await _securityIdentityService.GetRolesAsync(user.Id.ToString());
                if (!roles.Contains(nameof(Roles.Admin)) && !roles.Contains(nameof(Roles.Doctor)))
                {
                    patientsOnly.Add(user);
                }
            }

            var selectItems = patientsOnly.Select(e => new
            {
                Id = e.Id,
                DisplayText = $"[{e.Id}] {e.UserName}"
            });

            ViewBag.PatientsList = new SelectList(selectItems, "Id", "DisplayText", userId);
        }
    }
}
