using System.Diagnostics;
using Hrubos.HospitalSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hrubos.HospitalSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue && statusCode.Value == 404)
            {
                return View("NotFound");
            }

            // Pokud statusCode je null, znamená to, že to spadlo na nìjakou výjimku
            return View("Error", new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
