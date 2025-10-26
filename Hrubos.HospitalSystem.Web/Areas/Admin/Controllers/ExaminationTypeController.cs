using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;

namespace Hrubos.HospitalSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Doctor))]
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
            bool updated = _examinationTypeAppService.Edit(id, examinationType);

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
