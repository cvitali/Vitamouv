using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Vitamouv.Models;
using Vitamouv.Services.Emails;


namespace Vitamouv.Controllers
{
    public class ContactFormController : Controller
    {
        //injection de dépendance du service d'email pour permettre l'envoi d'emails de contact
        private readonly IEmailService _emailService;
        public ContactFormController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        //récupération des données du formulaire pour créer un model d'email et l'envoyer via le service d'email
        [HttpPost]
        public IActionResult Contact(ContactFormViewModel form)
        {
            //renvoie le formulaire en cas d'erreur
            if (!ModelState.IsValid)
            {
                return PartialView("_ContactButtonPartial", form);
            }

            //créer un model d'email à partir du formulaire
            var newEmail = new ContactEmailModel
            {
                Status = form.Status,
                FirstName = form.FirstName,
                LastName = form.LastName,
                Institute = form.Institute,
                Town = form.Town,
                Phone = form.Phone,
                Email = form.Email,
                //on donne une valeur par défaut au sujet si l'utilisateur ne le renseigne pas
                Subject = string.IsNullOrEmpty(form.Subject) ? "Demande de renseignements" : form.Subject,
                Message = form.Message
            };
            //communiquer avec le service d'email pour envoyer le message
            _emailService.SendContactEmail(newEmail);
            {
                if (_emailService.SendContactEmail(newEmail).Result == true)
                {
                    return Ok(new { message = "formulaire envoyé" });
                }
                else
                {
                    return BadRequest(new { message = "une erreur est survenue lors de l'envoi du formulaire" });
                }
                //return PartialView("_ContactButtonPartial", form);
            }
        }

    }
}

//1_récupérer les entrées utilisateurs
//2_récupérer le model d'email
//3_CRéer un model d'email
//  |--> qui sera récupéré par IServiceEmail