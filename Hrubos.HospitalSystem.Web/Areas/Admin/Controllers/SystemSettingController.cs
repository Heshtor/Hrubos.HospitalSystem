using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class SystemSettingController : Controller
    {
        private readonly ISystemSettingAppService _systemSettingAppService;
        private readonly ILogger<SystemSettingController> _logger;

        public SystemSettingController(ISystemSettingAppService systemSettingAppService, ILogger<SystemSettingController> logger)
        {
            _systemSettingAppService = systemSettingAppService;
            _logger = logger;
        }

        public IActionResult Select()
        {
            _logger.LogInformation("Uživatel zobrazil seznam nastavení v nemocničním systému.");
            var systemSettings = _systemSettingAppService.SelectAll();
            return View(systemSettings);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var systemSetting = _systemSettingAppService.GetById(id);

            if (systemSetting == null)
            {
                return NotFound();
            }

            return View(systemSetting);
        }

        [HttpPost]
        public IActionResult Edit(int id, SystemSetting systemSetting)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace nastavení v nemocničním systému s ID {id} selhala kvůli validaci.", id);

                return View(systemSetting);
            }

            bool updated = _systemSettingAppService.Edit(id, systemSetting);

            if (updated)
            {
                _logger.LogInformation("Editace nastavení v nemocničním systému s ID {id} proběhla úspěšně.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o editaci neexistujícího nastavení v nemocničním systému s ID {id}.", id);
                return NotFound();
            }
        }
    }
}
