using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class VaccineTypeController : Controller
    {
        private readonly IVaccineTypeAppService _vaccineTypeAppService;
        private readonly ILogger<VaccineTypeController> _logger;

        public VaccineTypeController(IVaccineTypeAppService vaccineTypeAppService, ILogger<VaccineTypeController> logger)
        {
            _vaccineTypeAppService = vaccineTypeAppService;
            _logger = logger;
        }

        public IActionResult Select()
        {
            _logger.LogInformation("Uživatel zobrazil seznam typů vakcín.");
            var vaccineTypes = _vaccineTypeAppService.SelectAll();
            return View(vaccineTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VaccineType vaccineType)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Vytvoření typu vakcíny selhalo kvůli validaci.");

                return View(vaccineType);
            }

            try
            {
                _vaccineTypeAppService.Create(vaccineType);
                _logger.LogInformation("Vytvořen nový typ vakcíny s ID {id}.", vaccineType.Id);
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření typu vakcíny.");
                return View("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _vaccineTypeAppService.Delete(id);

            if (deleted)
            {
                _logger.LogInformation("Smazán typ vakcíny s ID {id}.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o smazání neexistujícího typu vakcíny s ID {id}.", id);
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vaccineType = _vaccineTypeAppService.GetById(id);

            if (vaccineType == null)
            {
                return NotFound();
            }

            return View(vaccineType);
        }

        [HttpPost]
        public IActionResult Edit(int id, VaccineType vaccineType)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace typu vakcíny s ID {id} selhala kvůli validaci.", id);

                return View(vaccineType);
            }

            bool updated = _vaccineTypeAppService.Edit(id, vaccineType);

            if (updated)
            {
                _logger.LogInformation("Editace typu vakcíny s ID {id} proběhla úspěšně.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o editaci neexistujícího typu vakcíny s ID {id}.", id);
                return NotFound();
            }
        }
    }
}
