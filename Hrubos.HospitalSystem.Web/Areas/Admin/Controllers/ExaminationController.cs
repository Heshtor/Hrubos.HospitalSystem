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
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doctor))]
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

        public IActionResult Select()
        {
            _logger.LogInformation("Uživatel zobrazil seznam vyšetření.");
            var examinations = _examinationAppService.SelectAll();
            return View(examinations);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SetExaminationTypeSelectList();
            await SetPatientSelectList();
            await SetDoctorSelectList();

            return View(new Examination());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Examination examination)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Vytvoření vyšetření selhalo kvůli validaci.");

                SetExaminationTypeSelectList(examination.ExaminationTypeId);
                await SetPatientSelectList(examination.PatientId);
                await SetDoctorSelectList(examination.DoctorId);

                return View(examination);
            }

            try
            {
                _examinationAppService.Create(examination);
                _logger.LogInformation("Vytvořeno nové vyšetření s ID {id}.", examination.Id);
                return RedirectToAction(nameof(Select));
            }
            catch (InvalidOperationException ex) // již naplněná kapacita
            {
                ModelState.AddModelError(nameof(Examination.DateTime), ex.Message);

                _logger.LogWarning(ex, "Pokus o vytvoření vyšetření nad denní limit doktora.");

                SetExaminationTypeSelectList(examination.ExaminationTypeId);
                await SetPatientSelectList(examination.PatientId);
                await SetDoctorSelectList(examination.DoctorId);

                return View(examination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření vyšetření.");
                return View("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _examinationAppService.Delete(id);

            if (deleted)
            {
                _logger.LogInformation("Smazáno vyšetření s ID {id}.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o smazání neexistujícího vyšetření s ID {id}.", id);
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var examination = _examinationAppService.GetById(id);

            if (examination == null)
            {
                return NotFound();
            }

            SetExaminationTypeSelectList(examination.ExaminationTypeId);
            await SetPatientSelectList(examination.PatientId);
            await SetDoctorSelectList(examination.DoctorId);

            return View(examination);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Examination examination)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace vyšetření s ID {id} selhala kvůli validaci.", id);

                SetExaminationTypeSelectList(examination.ExaminationTypeId);
                await SetPatientSelectList(examination.PatientId);
                await SetDoctorSelectList(examination.DoctorId);

                return View(examination);
            }

            try
            {
                bool updated = _examinationAppService.Edit(id, examination);

                if (updated)
                {
                    _logger.LogInformation("Editace vyšetření s ID {id} proběhla úspěšně.", id);
                    return RedirectToAction(nameof(Select));
                }
                else
                {
                    _logger.LogWarning("Pokus o editaci neexistujícího vyšetření s ID {id}.", id);
                    return NotFound();
                }
            }
            catch (InvalidOperationException ex) // již naplněná kapacita
            {
                ModelState.AddModelError(nameof(Examination.DateTime), ex.Message);

                _logger.LogWarning(ex, "Pokus o vytvoření vyšetření nad denní limit doktora.");

                SetExaminationTypeSelectList(examination.ExaminationTypeId);
                await SetPatientSelectList(examination.PatientId);
                await SetDoctorSelectList(examination.DoctorId);

                return View(examination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při editaci vakcinace.");
                return View("Error");
            }
        }

        void SetExaminationTypeSelectList(int? examinationTypeId = null)
        {
            var examinationTypes = _examinationTypeAppService.SelectAll();

            var selectItems = examinationTypes.Select(e => new
            {
                Id = e.Id,
                DisplayText = $"[{e.Id}] {e.Name}"
            });

            ViewBag.ExaminationTypesList = new SelectList(selectItems, "Id", "DisplayText", examinationTypeId);
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

        async Task SetDoctorSelectList(int? userId = null)
        {
            var allUsers = await _securityIdentityService.GetAllUsersAsync();

            var doctorsOnly = new List<User>();
            foreach (var user in allUsers)
            {
                var roles = await _securityIdentityService.GetRolesAsync(user.Id.ToString());
                if (!roles.Contains(nameof(Roles.Admin)) && !roles.Contains(nameof(Roles.Patient)))
                {
                    doctorsOnly.Add(user);
                }
            }

            var selectItems = doctorsOnly.Select(e => new
            {
                Id = e.Id,
                DisplayText = $"[{e.Id}] {e.UserName}"
            });

            ViewBag.DoctorsList = new SelectList(selectItems, "Id", "DisplayText", userId);
        }
    }
}
