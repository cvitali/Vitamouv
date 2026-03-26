using Vitamouv.Models;

namespace Vitamouv.Services.Emails
{
    //interface pour le service d'email, qui définit la méthode d'envoi d'un email de contact
    //permet de séparer la logique d'envoi d'email du reste de l'application, et de faciliter les tests,
    //la maintenance ou le changeement de la logique d'envoi sans impacter les autres parties du code
    public interface IEmailService
    {   
        //on utilise Task parceque la méthode sera asynchrone
        //Task<bool> afin de récupérer true ou false selon que la méthode fonctionne ou échoue
        Task<bool> SendContactEmail(ContactEmailModel newEmail);
    }
}
