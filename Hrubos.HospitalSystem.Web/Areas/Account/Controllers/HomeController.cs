using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Application.ViewModels;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Domain.Entities.Interfaces;
using Hrubos.HospitalSystem.Infrastructure.Identity;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hrubos.HospitalSystem.Web.Areas.Account.Controllers
{
    [Area("Account")]
    public class HomeController : Controller
    {
        private readonly IAccountIdentityService _accountService;
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ISpecializationAppService _specializationAppService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IAccountIdentityService security, ISecurityIdentityService securityIdentityService, ISpecializationAppService specializationAppService, ILogger<HomeController> logger)
        {
            _accountService = security;
            _securityIdentityService = securityIdentityService;
            _specializationAppService = specializationAppService;
            _logger = logger;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                string[] errors = await _accountService.Register(registerVM, Roles.Patient);

                if (errors == null)
                {
                    _logger.LogInformation("Byl zaregistrován nový uživatel.");

                    //login the user after registration
                    LoginViewModel loginVM = new LoginViewModel()
                    {
                        UserName = registerVM.UserName,
                        Password = registerVM.Password
                    };

                    bool isLogged = await _accountService.Login(loginVM);
                    if (isLogged)
                        return base.RedirectToAction(nameof(Web.Controllers.HomeController.Index), nameof(Web.Controllers.HomeController).Replace(nameof(Controller), string.Empty), new { area = string.Empty });
                    else
                        return RedirectToAction(nameof(Login));
                }
                else
                {
                    _logger.LogError("Chyba při registraci uživatele: {errors}", string.Join(", ", errors));
                }
            }

            return View(registerVM);
        }


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) // pokud je už uživatel přihlášen, nepovolíme znovu přihlášení
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (User.Identity.IsAuthenticated) // pokud je už uživatel přihlášen, nepovolíme znovu přihlášení
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            if (ModelState.IsValid)
            {
                bool isLogged = await _accountService.Login(loginVM);
                if (isLogged)
                {
                    _logger.LogInformation("Uživatel byl úspěšně přihlášen.");
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                _logger.LogInformation("Uživatel se pokusil přihlásit, ale neúspěšně.");
                loginVM.LoginFailed = true;
            }

            return View(loginVM);
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            _logger.LogInformation("Uživatel byl odhlášen.");
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult AccessDenied(string authorize)
        {
            _logger.LogInformation("Uživatel se pokusil dostat na stránku, na kterou nemá práva.");

            // Pokud uživatel napsal adresu ručně, přesměrujeme ho na domovskou stránku
            if (authorize != "false")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            User currentUser = await _securityIdentityService.GetCurrentUserAsync(User);

            if (currentUser == null)
            {
                return NotFound();
            }

            var roles = await _securityIdentityService.GetRolesAsync(currentUser.Id.ToString());
            currentUser.RoleName = roles.FirstOrDefault() ?? "bez role";

            _logger.LogInformation("Uživatel zobrazil svoje osobní údaje.");

            return View(currentUser);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            User currentUser = await _securityIdentityService.GetCurrentUserAsync(User);

            if (currentUser == null)
            {
                return NotFound();
            }

            if (User.IsInRole(nameof(Roles.Doctor)))
            {
                SetSpecializationsSelectList(currentUser.SpecializationId);
            }

            return View(currentUser);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(User newUserData)
        {
            User currentUser = await _securityIdentityService.GetCurrentUserAsync(User);

            if (currentUser == null)
            {
                return NotFound();
            }

            newUserData.Id = currentUser.Id;

            var roles = await _securityIdentityService.GetRolesAsync(currentUser.Id.ToString());
            newUserData.RoleName = roles.FirstOrDefault(); // aby si uživatel nemohl změnit svou roli

            ModelState.Remove(nameof(newUserData.UserName)); // neměním uživatelské jméno, proto nekontroluji jeho validitu

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace osobních údajů uživatele s ID {id} selhala kvůli validaci.", currentUser.Id);

                if (User.IsInRole(nameof(Roles.Doctor)))
                {
                    SetSpecializationsSelectList(newUserData.SpecializationId);
                }

                return View(newUserData);
            }

            bool updated = await _securityIdentityService.EditUserAsync(newUserData);

            if (updated)
            {
                _logger.LogInformation("Editace osobních údajů uživatele s ID {id} proběhla úspěšně.", currentUser.Id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning("Pokus o editaci osobních údajů uživatele s ID {id}.", currentUser.Id);
                return NotFound();
            }
        }

        void SetSpecializationsSelectList(int? specializationId)
        {
            var specializations = _specializationAppService.SelectAll();
            ViewBag.SpecializationsList = new SelectList(specializations, nameof(Specialization.Id), nameof(Specialization.Name), specializationId);
        }
    }
}
