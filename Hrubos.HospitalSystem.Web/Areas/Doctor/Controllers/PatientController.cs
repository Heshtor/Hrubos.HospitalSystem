using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hrubos.HospitalSystem.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = nameof(Roles.Doctor))]
    public class PatientController : Controller
    {
        private readonly IDoctorPatientAppService _doctorPatientAppService;
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IDoctorPatientAppService doctorPatientAppService, ISecurityIdentityService securityIdentityService, ILogger<PatientController> logger)
        {
            _doctorPatientAppService = doctorPatientAppService;
            _securityIdentityService = securityIdentityService;
            _logger = logger;
        }

        public async Task<IActionResult> Select()
        {
            _logger.LogInformation("Doktor zobrazil seznam svých pacientů.");

            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User); // aktuálně přihlášený doktor
            if (currentUser == null) return NotFound();

            var allRelations = _doctorPatientAppService.SelectAll(); // všechny vazby doktor-pacient

            var myPatients = allRelations
                .Where(dp => dp.DoctorId == currentUser.Id)
                .ToList(); // vazby pouze pro aktuálního doktora

            return View(myPatients);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await SetPatientSelectList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorPatient doctorPatient)
        {
            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User); // aktuálně přihlášený doktor
            if (currentUser == null) return NotFound();

            doctorPatient.DoctorId = currentUser.Id;

            ModelState.Remove(nameof(DoctorPatient.DoctorId));
            ModelState.Remove(nameof(DoctorPatient.Doctor));

            // Kontrola, zda již doktor nemá přiřazeného daného pacienta
            var existingRelations = _doctorPatientAppService.SelectAll();
            bool alreadyExists = existingRelations.Any(dp => dp.DoctorId == currentUser.Id && dp.PatientId == doctorPatient.PatientId);

            if (alreadyExists) // pokud doktor již má daného pacienta přiřazeného
            {
                ModelState.AddModelError(string.Empty, "Tohoto pacienta už máte v péči.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Přidání pacienta doktorovi selhalo kvůli validaci.");

                await SetPatientSelectList(doctorPatient.PatientId);

                return View(doctorPatient);
            }

            try
            {
                _doctorPatientAppService.Create(doctorPatient);
                _logger.LogInformation("Doktor s ID {docId} přidal pacienta s ID {patId} do své péče.", currentUser.Id, doctorPatient.PatientId);
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při přidávání pacienta doktorovi.");
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var relation = _doctorPatientAppService.GetById(id);
            if (relation == null) return NotFound();

            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User);
            if (relation.DoctorId != currentUser.Id)
            {
                _logger.LogWarning("Doktor s ID {docId} se pokusil smazat cizí vazbu doktor-pacient s ID {relId}.", currentUser.Id, id);

                Response.StatusCode = 403;
                return View("~/Areas/Account/Views/Home/AccessDenied.cshtml");
            }

            bool deleted = _doctorPatientAppService.Delete(id);

            if (deleted)
            {
                _logger.LogInformation("Odebrán pacient z péče doktora (vazba ID {id}).", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o smazání neexistující vazby doktor-pacient s ID {id}.", id);
                return NotFound();
            }
        }

        async Task SetPatientSelectList(int? userId = null)
        {
            var allUsers = await _securityIdentityService.GetAllUsersAsync();
            var currentUser = await _securityIdentityService.GetCurrentUserAsync(User);

            // Moji pacienti
            var myCurrentPatientIds = _doctorPatientAppService.SelectAll()
                                        .Where(dp => dp.DoctorId == currentUser.Id)
                                        .Select(dp => dp.PatientId)
                                        .ToList();

            var availablePatients = new List<User>();
            foreach (var user in allUsers)
            {
                var roles = await _securityIdentityService.GetRolesAsync(user.Id.ToString());

                // Pouze pacienti, které ještě nemám v péči
                bool isPatient = !roles.Contains(nameof(Roles.Admin)) && !roles.Contains(nameof(Roles.Doctor));
                bool isNotMyPatientYet = !myCurrentPatientIds.Contains(user.Id);

                if (isPatient && isNotMyPatientYet)
                {
                    availablePatients.Add(user);
                }
            }

            var selectItems = availablePatients.Select(e => new
            {
                Id = e.Id,
                DisplayText = $"{e.FirstName} {e.LastName} ({e.UserName})"
            });

            ViewBag.PatientsList = new SelectList(selectItems, "Id", "DisplayText", userId);
        }
    }
}
