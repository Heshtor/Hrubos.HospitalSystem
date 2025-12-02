using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doctor))]
    public class VaccinationController : Controller
    {
        private readonly IVaccinationAppService _vaccinationAppService;
        private readonly ILogger<VaccinationController> _logger;

        public VaccinationController(IVaccinationAppService vaccinationAppService, ILogger<VaccinationController> logger)
        {
            _vaccinationAppService = vaccinationAppService;
            _logger = logger;
        }

        public IActionResult Select()
        {
            _logger.LogInformation("Uživatel zobrazil seznam vakcinací.");
            var vaccinations = _vaccinationAppService.SelectAll();
            return View(vaccinations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vaccination vaccination)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Vytvoření vakcinace selhalo kvůli validaci.");

                return View(vaccination);
            }

            try
            {
                _vaccinationAppService.Create(vaccination);
                _logger.LogInformation("Vytvořena nová vakcinace s ID {id}.", vaccination.Id);
                return RedirectToAction(nameof(Select));
            }
            catch (InvalidOperationException ex) // Již naplněná kapacita
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                _logger.LogWarning(ex, "Pokus o vytvoření vakcinace nad denní limit.");

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
        public IActionResult Edit(int id)
        {
            var vaccination = _vaccinationAppService.GetById(id);

            if (vaccination == null)
            {
                return NotFound();
            }

            return View(vaccination);
        }

        [HttpPost]
        public IActionResult Edit(int id, Vaccination vaccination)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace vakcinace s ID {id} selhala kvůli validaci.", id);

                return View(vaccination);
            }

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
    }
}
