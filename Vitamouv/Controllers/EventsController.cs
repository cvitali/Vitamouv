using Microsoft.AspNetCore.Mvc;

namespace Vitamouv.Controllers
{
    [Route("Prestations/Event'MOUV")]
    public class EventsController : Controller
    {
        [Route("Anniversaires sportifs")]
        public IActionResult Birthday()
        {
            return View();
        }

        [Route("Création d'événements")]
        public IActionResult EventsCreation()
        {
            return View();
        }

        [Route("Ouvertures de bals de mariages")]
        public IActionResult Wedding()
        {
            return View();
        }
    }

    
}
