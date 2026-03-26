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
            //on s'assure que le formulaire est correctement rempli
            //et on transforme les erreurs de validation MVC en un objet JSON exploitable côté js
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage)
                        )
                });
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
            var response = _emailService.SendContactEmail(newEmail);
            
                if (response.Result == true)
                {
                return Ok(new { message = "formulaire envoyé" });
                }
                else
                {
                return BadRequest(new { message = "une erreur est survenue lors de l'envoi du formulaire" });
            }

        

        }

    }
}