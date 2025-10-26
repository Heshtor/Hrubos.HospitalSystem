using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Application.ViewModels;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Hrubos.HospitalSystem.Web.Controllers;

namespace Hrubos.HospitalSystem.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {

        IAccountIdentityService _accountService;

        public AccountController(IAccountIdentityService security)
        {
            _accountService = security;
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
                    //login the user after registration
                    LoginViewModel loginVM = new LoginViewModel()
                    {
                        Username = registerVM.Username,
                        Password = registerVM.Password
                    };

                    bool isLogged = await _accountService.Login(loginVM);
                    if (isLogged)
                        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
                    else
                        return RedirectToAction(nameof(Login));
                }
                else
                {
                    //errors to logger
                }

            }

            return View(registerVM);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                bool isLogged = await _accountService.Login(loginVM);
                if (isLogged)
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });

                loginVM.LoginFailed = true;
            }

            return View(loginVM);
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return RedirectToAction(nameof(Login));
        }

    }
}
