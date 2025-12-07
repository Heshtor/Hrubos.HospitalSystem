using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    [Authorize(Roles = nameof(Roles.Patient))]
    public class ExaminationResultController : Controller
    {
        private readonly IExaminationResultAppService _examinationResultAppService;
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ILogger<ExaminationResultController> _logger;

        public ExaminationResultController(IExaminationResultAppService examinationResultAppService, IExaminationAppService examinationAppService, ISecurityIdentityService securityIdentityService, ILogger<ExaminationResultController> logger)
        {
            _examinationResultAppService = examinationResultAppService;
            _securityIdentityService = securityIdentityService;
            _logger = logger;
        }

        public async Task<IActionResult> Select(int id)
        {
            var result = _examinationResultAppService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning("Pokus o zobrazení neexistujícího výsledku vyšetření s ID {id}.", id);
                return NotFound();
            }

            var currentPatient = await _securityIdentityService.GetCurrentUserAsync(User); // aktuální přihlášený pacient

            // Kontrola, zda patří tento výsledek vyšetření aktuálnímu pacientovi
            if (result.Examination.PatientId != currentPatient.Id)
            {
                _logger.LogWarning("Pacient s ID {patId} se pokusil zobrazit cizí výsledek vyšetření s ID {resId}.", currentPatient.Id, id);

                Response.StatusCode = 403;
                return View("~/Areas/Account/Views/Home/AccessDenied.cshtml");
            }

            _logger.LogInformation("Pacient s ID {patId} zobrazil svůj výsledek vyšetření s ID {resId}.", currentPatient.Id, id);
            return View(result);
        }
    }
}
