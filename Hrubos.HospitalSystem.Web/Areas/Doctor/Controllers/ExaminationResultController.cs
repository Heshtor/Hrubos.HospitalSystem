using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = nameof(Roles.Doctor))]
    public class ExaminationResultController : Controller
    {
        private readonly IExaminationResultAppService _examinationResultAppService;
        private readonly IExaminationAppService _examinationAppService;
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ILogger<ExaminationResultController> _logger;

        public ExaminationResultController(IExaminationResultAppService examinationResultAppService, IExaminationAppService examinationAppService, ISecurityIdentityService securityIdentityService, ILogger<ExaminationResultController> logger)
        {
            _examinationResultAppService = examinationResultAppService;
            _examinationAppService = examinationAppService;
            _securityIdentityService = securityIdentityService;
            _logger = logger;
        }

        public IActionResult Select(int id)
        {
            var result = _examinationResultAppService.GetById(id);
            if (result == null)
            {
                _logger.LogWarning("Pokus o zobrazení neexistujícího výsledku vyšetření s ID {id}.", id);
                return NotFound();
            }

            _logger.LogInformation("Doktor zobrazil výsledek vyšetření s ID {id}.", id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int examinationId)
        {
            var examination = _examinationAppService.GetById(examinationId);
            if (examination == null) return NotFound();

            var currentDoctor = await _securityIdentityService.GetCurrentUserAsync(User);
            if (examination.DoctorId != currentDoctor.Id)
            {
                _logger.LogWarning("Doktor s ID {docId} se pokusil vytvořit výsledek pro cizí vyšetření s ID {examId}.", currentDoctor.Id, examinationId);

                Response.StatusCode = 403;
                return View("~/Areas/Account/Views/Home/AccessDenied.cshtml");
            }

            ViewBag.PatientId = examination.PatientId;

            var model = new ExaminationResult
            {
                ExaminationId = examinationId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExaminationResult examinationResult)
        {
            int examId = examinationResult.ExaminationId.GetValueOrDefault();

            var exam = _examinationAppService.GetById(examId);

            if (exam == null)
            {
                // Pokud ID neexistuje nebo bylo 0
                return NotFound("Vyšetření nebylo nalezeno.");
            }

            // Kontrola, zda vyšetření patří aktuálnímu doktorovi
            var currentDoctor = await _securityIdentityService.GetCurrentUserAsync(User);
            if (exam.DoctorId != currentDoctor.Id) return Unauthorized();

            // Kontrola, zda již pro dané vyšetření existuje výsledek
            var existingResult = _examinationResultAppService.SelectAll()
                .FirstOrDefault(r => r.ExaminationId == examId);

            if (existingResult != null)
            {
                ModelState.AddModelError(string.Empty, "Výsledek pro toto vyšetření již existuje.");
            }

            ModelState.Remove(nameof(ExaminationResult.Examination));

            if (!ModelState.IsValid)
            {
                ViewBag.PatientId = exam.PatientId;
                return View(examinationResult);
            }

            try
            {
                _examinationResultAppService.Create(examinationResult);
                _logger.LogInformation("Vytvořen výsledek s ID {resId} pro vyšetření s ID {examId}.", examinationResult.Id, examId);

                return RedirectToAction("Select", "Examination", new { patientId = exam.PatientId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření výsledku vyšetření.");
                ViewBag.PatientId = exam.PatientId;
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = _examinationResultAppService.GetById(id);

            if (result == null) return NotFound();

            var exam = result.Examination;

            if (exam == null)
            {
                return NotFound("Chyba dat: Výsledek nemá přiřazené vyšetření.");
            }

            // Kontrola, zda vyšetření patří aktuálnímu doktorovi
            var currentDoctor = await _securityIdentityService.GetCurrentUserAsync(User);

            if (exam.DoctorId != currentDoctor.Id)
            {
                _logger.LogWarning("Doktor s ID {docId} se pokusil smazat cizí výsledek vyšetření s ID {resId}.", currentDoctor.Id, id);
                return Unauthorized();
            }

            _examinationResultAppService.Delete(id);
            _logger.LogInformation("Smazán výsledek vyšetření s ID {id}.", id);

            return RedirectToAction("Select", "Examination", new { patientId = exam.PatientId });
        }
    }
}