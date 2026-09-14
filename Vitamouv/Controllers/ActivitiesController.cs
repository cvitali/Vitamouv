using Microsoft.AspNetCore.Mvc;

namespace Vitamouv.Controllers
{
    [Route("Prestations")]
    public class ActivitiesController : Controller
    {
        [Route("Dance'MOUV")]
        public IActionResult Dancemouv()
        {
            return View();
        }

        [Route("Event'MOUV")]
        public IActionResult EventsCreation()
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

        [Route("Animat'MOUV")]
        public IActionResult Animatmouv()
        {
            return View();
        }
    }
}
