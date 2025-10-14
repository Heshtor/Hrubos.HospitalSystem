using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExaminationType examinationType)
        {
            _examinationTypeAppService.Create(examinationType);

            return RedirectToAction(nameof(Select));
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _examinationTypeAppService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(Select));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
