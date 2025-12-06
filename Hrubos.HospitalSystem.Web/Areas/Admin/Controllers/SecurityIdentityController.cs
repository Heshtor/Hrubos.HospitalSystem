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
    public class SecurityIdentityController : Controller
    {
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ISpecializationAppService _specializationAppService;
        private readonly ILogger<ExaminationResultController> _logger;

        public SecurityIdentityController(ISecurityIdentityService securityIdentityService, ISpecializationAppService specializationAppService, ILogger<ExaminationResultController> logger)
        {
            _securityIdentityService = securityIdentityService;
            _specializationAppService = specializationAppService;
            _logger = logger;
        }

        public async Task <IActionResult> Select()
        {
            _logger.LogInformation("Admin zobrazil seznam všech uživatelů.");
            var users = await _securityIdentityService.GetAllUsersAsync();

            var nonAdminUsers = new List<User>();
            foreach (var user in users)
            {
                var roles = await _securityIdentityService.GetRolesAsync(user.Id.ToString());
                if (!roles.Contains(nameof(Roles.Admin)))
                {
                    user.RoleName = roles.FirstOrDefault() ?? "bez role";
                    nonAdminUsers.Add(user);
                }
            }

            return View(nonAdminUsers);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var currentUser = await _securityIdentityService.GetUserByIdAsync(id);

            if (currentUser == null)
            {
                return NotFound();
            }

            var roles = await _securityIdentityService.GetRolesAsync(currentUser.Id.ToString());
            currentUser.RoleName = roles.FirstOrDefault();

            SetSpecializationsSelectList(currentUser.SpecializationId);
            SetRolesSelectList(currentUser.RoleName);

            return View(currentUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, User newUserData)
        {
            newUserData.Id = int.Parse(id);

            ModelState.Remove(nameof(newUserData.UserName)); // neměním uživatelské jméno, proto nekontroluji jeho validitu

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace uživatele s ID {id} selhala kvůli validaci.", id);

                SetSpecializationsSelectList(newUserData.SpecializationId);
                SetRolesSelectList(newUserData.RoleName);

                return View(newUserData);
            }

            bool updated = await _securityIdentityService.EditUserAsync(newUserData);

            if (updated)
            {
                _logger.LogInformation("Editace uživatele s ID {id} proběhla úspěšně.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o editaci neexistujícího uživatele s ID {id}.", id);
                return NotFound();
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _securityIdentityService.DeleteUserAsync(id);

            if (deleted)
            {
                _logger.LogInformation("Smazán uživatel s ID {id}.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o smazání neexistujícího uživatele s ID {id}.", id);
                return NotFound();
            }
        }

        void SetSpecializationsSelectList(int? specializationId)
        {
            var specializations = _specializationAppService.SelectAll();

            var selectItems = specializations.Select(e => new
            {
                Id = e.Id,
                DisplayText = $"[{e.Id}] {e.Name}"
            });

            ViewBag.SpecializationsList = new SelectList(selectItems, "Id", "DisplayText", specializationId);
        }

        void SetRolesSelectList(string? selectedRole)
        {
            var roles = Enum.GetNames(typeof(Roles)).ToList();

            ViewBag.RolesList = new SelectList(roles, selectedRole);
        }
    }
}
