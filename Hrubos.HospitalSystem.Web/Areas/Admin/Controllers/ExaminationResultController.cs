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
        IExaminationResultAppService _examinationResultAppService;
        public ExaminationResultController(IExaminationResultAppService examinationResultAppService)
        {
            _examinationResultAppService = examinationResultAppService;
        }

        public IActionResult Select()
        {
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
            _examinationResultAppService.Create(examinationResult);

            return RedirectToAction(nameof(Select));
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _examinationResultAppService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(Select));
            }
            else
            {
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
            bool updated = _examinationResultAppService.Edit(id, examinationResult);

            if (updated)
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
