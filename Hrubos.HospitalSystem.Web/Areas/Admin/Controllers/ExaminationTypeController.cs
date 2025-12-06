using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ExaminationTypeController : Controller
    {
        private readonly IExaminationTypeAppService _examinationTypeAppService;
        private readonly ILogger<ExaminationTypeController> _logger;

        public ExaminationTypeController(IExaminationTypeAppService examinationTypeAppService, ILogger<ExaminationTypeController> logger)
        {
            _examinationTypeAppService = examinationTypeAppService;
            _logger = logger;
        }

        public IActionResult Select()
        {
            _logger.LogInformation("Uživatel zobrazil seznam typů vyšetření.");
            var examinationTypes = _examinationTypeAppService.SelectAll();
            return View(examinationTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExaminationType examinationType)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Vytvoření typu vyšetření selhalo kvůli validaci.");

                return View(examinationType);
            }

            try
            {
                _examinationTypeAppService.Create(examinationType);
                _logger.LogInformation("Vytvořena nový typ vyšetření s ID {id}.", examinationType.Id);
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření typu vyšetření.");
                return View("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _examinationTypeAppService.Delete(id);

            if (deleted)
            {
                _logger.LogInformation("Smazán typ vyšetření s ID {id}.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o smazání neexistujícího typu vyšetření s ID {id}.", id);
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var examinationType = _examinationTypeAppService.GetById(id);

            if (examinationType == null)
            {
                return NotFound();
            }

            return View(examinationType);
        }

        [HttpPost]
        public IActionResult Edit(int id, ExaminationType examinationType)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace typu vyšetření s ID {id} selhala kvůli validaci.", id);

                return View(examinationType);
            }

            bool updated = _examinationTypeAppService.Edit(id, examinationType);

            if (updated)
            {
                _logger.LogInformation("Editace typu vyšetření s ID {id} proběhla úspěšně.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o editaci neexistujícího typu vyšetření s ID {id}.", id);
                return NotFound();
            }
        }
    }
}
