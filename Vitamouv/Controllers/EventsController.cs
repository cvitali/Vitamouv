using Microsoft.AspNetCore.Mvc;

namespace Vitamouv.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Birthday()
        {
            return View();
        }

        public IActionResult EventsCreation()
        {
            return View();
        }

        public IActionResult Wedding()
        {
            return View();
        }
    }

    
}
