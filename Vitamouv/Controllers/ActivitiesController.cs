using Microsoft.AspNetCore.Mvc;

namespace Vitamouv.Controllers
{
    [Route("Prestations")]
    public class ActivitiesController : Controller
    {
        [Route("Danse'MOUV")]
        public IActionResult Dansemouv()
        {
            return View();
        }

        [Route("Event'MOUV")]
        public IActionResult Eventmouv()
        {
            return View();
        }

        [Route("Mini'MOUV")]
        public IActionResult Minimouv()
        {
            return View();
        }

        [Route("School'MOUV")]
        public IActionResult Schoolmouv()
        {
            return View();
        }

        [Route("Slow'MOUV")]
        public IActionResult Slowmouv()
        {
            return View();
        }

    }
}
