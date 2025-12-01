using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doctor))]
    public class SpecializationController : Controller
    {
        private readonly ISpecializationAppService _specializationAppService;
        private readonly ILogger<SpecializationController> _logger;

        public SpecializationController(ISpecializationAppService specializationAppService, ILogger<SpecializationController> logger)
        {
            _specializationAppService = specializationAppService;
            _logger = logger;
        }

        public IActionResult Select()
        {
            _logger.LogInformation("Uživatel zobrazil seznam specializací.");
            var specializations = _specializationAppService.SelectAll();
            return View(specializations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Specialization specialization)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Vytvoření specializace selhalo kvůli validaci.");

                return View(specialization);
            }

            try
            {
                _specializationAppService.Create(specialization);
                _logger.LogInformation("Vytvořena nová specializace s ID {id}.", specialization.Id);
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření specializace.");
                return View("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _specializationAppService.Delete(id);

            if (deleted)
            {
                _logger.LogInformation("Smazána specializace s ID {id}.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o smazání neexistující specializace s ID {id}.", id);
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var specialization = _specializationAppService.GetById(id);

            if (specialization == null)
            {
                return NotFound();
            }

            return View(specialization);
        }

        [HttpPost]
        public IActionResult Edit(int id, Specialization specialization)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace specializace s ID {id} selhala kvůli validaci.", id);

                return View(specialization);
            }

            bool updated = _specializationAppService.Edit(id, specialization);

            if (updated)
            {
                _logger.LogInformation("Editace specializace s ID {id} proběhla úspěšně.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o editaci neexistující specializace s ID {id}.", id);
                return NotFound();
            }
        }
    }
}
