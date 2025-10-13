using Hrubos.HospitalSystem.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExaminationTypeController : Controller
    {
        IExaminationTypeAppService _examinationTypeAppService;
        public ExaminationTypeController(IExaminationTypeAppService examinationTypeAppService)
        {
            _examinationTypeAppService = examinationTypeAppService;
        }

        public IActionResult Select()
        {
            var examinationTypes = _examinationTypeAppService.SelectAll();
            return View(examinationTypes);
        }
    }
}
