using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = nameof(Roles.Doctor))]
    public class VaccinationController : Controller
    {
        private readonly IVaccinationAppService _vaccinationAppService;
        private readonly ISecurityIdentityService _securityIdentityService;
        private readonly ILogger<VaccinationController> _logger;

        public VaccinationController(IVaccinationAppService vaccinationAppService, ISecurityIdentityService securityIdentityService, ILogger<VaccinationController> logger)
        {
            _vaccinationAppService = vaccinationAppService;
            _securityIdentityService = securityIdentityService;
            _logger = logger;
        }

        public async Task<IActionResult> Select(int patientId)
        {
            _logger.LogInformation("Doktor zobrazil seznam očkování pro pacienta s ID {id}.", patientId);

            var allVaccinations = _vaccinationAppService.SelectAll(); // všechny očkování

            // Pouze očkování pro daného pacienta
            var patientVaccinations = allVaccinations
                .Where(v => v.PatientId == patientId)
                .OrderByDescending(v => v.DateTime) // sežazeno od nejnovějších
                .ToList();

            var patient = await _securityIdentityService.GetUserByIdAsync(patientId.ToString());
            if (patient != null)
            {
                ViewBag.PatientName = $"{patient.FirstName} {patient.LastName} ({patient.UserName})";
            }

            return View(patientVaccinations);
        }
    }
}
