using Hrubos.HospitalSystem.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecializationController : Controller
    {
        ISpecializationAppService _specializationAppService;
        public SpecializationController(ISpecializationAppService specializationAppService)
        {
            _specializationAppService = specializationAppService;
        }

        public IActionResult Select()
        {
            var specializations = _specializationAppService.SelectAll();
            return View(specializations);
        }
    }
}
