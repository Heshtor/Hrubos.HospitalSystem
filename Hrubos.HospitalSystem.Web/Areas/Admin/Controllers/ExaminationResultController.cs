using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doctor))]
    public class ExaminationResultController : Controller
    {
        private readonly IExaminationResultAppService _examinationResultAppService;
        private readonly ILogger<ExaminationResultController> _logger;

        public ExaminationResultController(IExaminationResultAppService examinationResultAppService, ILogger<ExaminationResultController> logger)
        {
            _examinationResultAppService = examinationResultAppService;
            _logger = logger;
        }

        public IActionResult Select()
        {
            _logger.LogInformation("Uživatel zobrazil seznam výsledků vyšetření.");
            var examinationResults = _examinationResultAppService.SelectAll();
            return View(examinationResults);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExaminationResult examinationResult)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Vytvoření výsledku vyšetření selhalo kvůli validaci.");
                return View(examinationResult);
            }

            try
            {
                _examinationResultAppService.Create(examinationResult);
                _logger.LogInformation("Vytvořen nový výsledek vyšetření pro pacienta s ID {ExaminationId}", examinationResult.ExaminationId);
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při ukládání výsledku vyšetření.");
                return View("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _examinationResultAppService.Delete(id);

            if (deleted)
            {
                _logger.LogInformation("Smazán výsledek vyšetření s ID {id}.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o smazání neexistujícího výsledku vyšetření s ID {id}.", id);
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var examinationResult = _examinationResultAppService.GetById(id);

            if (examinationResult == null)
            {
                return NotFound();
            }

            return View(examinationResult);
        }

        [HttpPost]
        public IActionResult Edit(int id, ExaminationResult examinationResult)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace výsledku vyšetření s ID {id} selhala kvůli validaci.", id);
                return View(examinationResult);
            }

            bool updated = _examinationResultAppService.Edit(id, examinationResult);

            if (updated)
            {
                _logger.LogInformation("Editace výsledku vyšetření s ID {id} proběhla úspěšně.", id);
                return RedirectToAction(nameof(Select));
            }
            else
            {
                _logger.LogWarning("Pokus o editaci neexistujícího výsledku vyšetření s ID {id}.", id);
                return NotFound();
            }
        }
    }
}
