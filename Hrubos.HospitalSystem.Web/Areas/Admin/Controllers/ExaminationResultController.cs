using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ExaminationResultController : Controller
    {
        private readonly IExaminationResultAppService _examinationResultAppService;
        private readonly IExaminationAppService _examinationAppService;
        private readonly ILogger<ExaminationResultController> _logger;

        public ExaminationResultController(IExaminationResultAppService examinationResultAppService, IExaminationAppService examinationAppService, ILogger<ExaminationResultController> logger)
        {
            _examinationResultAppService = examinationResultAppService;
            _examinationAppService = examinationAppService;
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
            SetExaminationsSelectList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(ExaminationResult examinationResult)
        {
            var existingExaminationResults = _examinationResultAppService.SelectAll()
                .FirstOrDefault(r => r.ExaminationId == examinationResult.ExaminationId);

            // Kontrola, zda již pro dané vyšetření existuje výsledek
            if (existingExaminationResults != null)
            {
                ModelState.AddModelError(nameof(ExaminationResult.ExaminationId), "Pro toto vyšetření již výsledek existuje!");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Vytvoření výsledku vyšetření selhalo kvůli validaci.");

                SetExaminationsSelectList(examinationResult.ExaminationId);

                return View(examinationResult);
            }

            try
            {
                _examinationResultAppService.Create(examinationResult);
                _logger.LogInformation("Vytvořen nový výsledek vyšetření s ID {id} pro vyšetření s ID {ExaminationId}.", examinationResult.Id, examinationResult.ExaminationId);
                return RedirectToAction(nameof(Select));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření výsledku vyšetření.");
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

            SetExaminationsSelectList(examinationResult.ExaminationId);

            return View(examinationResult);
        }

        [HttpPost]
        public IActionResult Edit(int id, ExaminationResult examinationResult)
        {
            var existingExaminationResults = _examinationResultAppService.SelectAll()
                .FirstOrDefault(r => r.ExaminationId == examinationResult.ExaminationId);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Editace výsledku vyšetření s ID {id} selhala kvůli validaci.", id);

                SetExaminationsSelectList(examinationResult.ExaminationId);

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

        void SetExaminationsSelectList(int? examinationId = null)
        {
            var allExaminations = _examinationAppService.SelectAll();

            var existingExaminationResults = _examinationResultAppService.SelectAll();

            var takenExaminationIds = existingExaminationResults
                .Select(r => r.ExaminationId)
                .Where(id => id != examinationId)
                .ToList();

            var availableExaminations = allExaminations
                .Where(e => !takenExaminationIds.Contains(e.Id))
                .Select(e => new
                {
                    Id = e.Id,
                    DisplayText = $"[{e.Id}] {e.ProblemDescription}"
                });

            ViewBag.ExaminationList = new SelectList(availableExaminations, "Id", "DisplayText", examinationId);
        }
    }
}
