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
    public class DoctorPatientController : Controller
    {
        private readonly IDoctorPatientAppService _doctorPatientAppService;
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ILogger<DoctorPatientController> _logger;

        public DoctorPatientController(IDoctorPatientAppService doctorPatientAppService, ISecurityIdentityService securityIdentityService, ILogger<DoctorPatientController> logger)
        {
            _doctorPatientAppService = doctorPatientAppService;
            _securityIdentityService = securityIdentityService;
            _logger = logger;
        }

        public IActionResult Select()
        {
            _logger.LogInformation("Uživatel zobrazil seznam vazeb doktor-pacient.");
            var doctorPatients = _doctorPatientAppService.SelectAll();
            return View(doctorPatients);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await SetPatientSelectList();
            await SetDoctorSelectList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorPatient doctorPatient)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Vytvoření vazby doktor-pacient selhalo kvůli validaci.");

                await SetPatientSelectList(doctorPatient.PatientId);
                await SetDoctorSelectList(doctorPatient.DoctorId);

                return View(doctorPatient);
            }

            try
            {
                _doctorPatientAppService.Create(doctorPatient);
                _logger.LogInformation("Vytvořena nová vazba doktor-pacient s ID {id}.", doctorPatient.Id);
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření vazby doktor-pacient.");
                return View("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _doctorPatientAppService.Delete(id);

            if (deleted)
            {
                _logger.LogInformation("Smazána vazba doktor-pacient s ID {id}.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o smazání neexistující vazby doktor-pacient s ID {id}.", id);
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var doctorPatient = _doctorPatientAppService.GetById(id);

            if (doctorPatient == null)
            {
                return NotFound();
            }

            await SetPatientSelectList(doctorPatient.PatientId);
            await SetDoctorSelectList(doctorPatient.DoctorId);

            return View(doctorPatient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DoctorPatient doctorPatient)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace vazby doktor-pacient s ID {id} selhala kvůli validaci.", id);

                await SetPatientSelectList(doctorPatient.PatientId);
                await SetDoctorSelectList(doctorPatient.DoctorId);

                return View(doctorPatient);
            }

            bool updated = _doctorPatientAppService.Edit(id, doctorPatient);

            if (updated)
            {
                _logger.LogInformation("Editace vazby doktor-pacient s ID {id} proběhla úspěšně.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o editaci neexistující vazby doktor-pacient s ID {id}.", id);
                return NotFound();
            }
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
