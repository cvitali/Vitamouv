using Vitamouv.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;

namespace Vitamouv.Services.Emails
{
    //implémentation du service d'email pour envoyer un email de contact
    //actuellement une implémentation fictive qui affiche les détails de l'email dans la console
    //dans une application réelle, cette classe pourrait utiliser un service d'email tiers ou un serveur SMTP pour envoyer les emails
    public class SendGridEmailService : IEmailService
    {
        //injection de dépendences afin de récupérer les secrets dans IConfiguration 
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        Task<bool> IEmailService.SendContactEmail(ContactEmailModel newEmail)
        {
            try
            {
                var apiKey = _configuration["SendGrid:ApiKey"];
                var client = new SendGridClient(apiKey);

                var message = new SendGridMessage
                {
                    From = new EmailAddress("desboiscorin@gmail.com"),
                    ReplyTo = new EmailAddress(newEmail.Email),
                    Subject = $"{newEmail.Status},{newEmail.Town} - {newEmail.Subject}",
                    HtmlContent = $"<p>Message de: {newEmail.FirstName} {newEmail.LastName}, {newEmail.Institute}</p><br/><p>Message: <br/>{newEmail.Message}</p><p>Contact: <br/>{newEmail.Email}, {newEmail.Phone}</p>"
                };

                message.AddTo(new EmailAddress("corinne.wilwert@yahoo.fr"));
                var response = client.SendEmailAsync(message).Result;

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return Task.FromResult(false);
            }


        }
    }
}
