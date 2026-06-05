using Vitamouv.Models;
using System.Diagnostics;
using brevo_csharp;
using brevo_csharp.Client;
using brevo_csharp.Model;
using SendGrid.Helpers.Mail.Model;
using System.Text.Json;

namespace Vitamouv.Services.Emails
{
    //implémentation du service d'email pour envoyer un email de contact
    public class BrevoEmailService(IConfiguration configuration) : IEmailService
    {
        //injection de dépendences afin de
        //1_récupérer les secrets dans IConfiguration 
        //2_utiliser HttpClient pour faire des requêtes HTTP à l'API de Brevo
        private readonly IConfiguration _configuration = configuration;
        private readonly HttpClient _httpClient = new HttpClient();
        private object? encoding;

        async Task<bool> IEmailService.SendContactEmail(ContactEmailModel newEmail)
        {
            try
            {
                var apiKey = _configuration["Brevo:ApiKey"];
                _httpClient.DefaultRequestHeaders.Add("api-key", apiKey);

                //création du payload (contenu de l'email) à envoyer à l'API de Brevo
                var payload  = new
                {
                    sender = new
                    {
                        name = "Vitamouv",
                        email = "admin.vitamouv@proton.me"
                    },
                    replyTo = new
                    {
                        name = $"{newEmail.FirstName} {newEmail.LastName}",
                        email = newEmail.Email
                    },
                    to = new[]
                    {
                            new {email = "nelly.vitali.57@gmail.com", name="Nelly Vitali" }
                    },
                    subject = $"{newEmail.Subject}",
                    htmlContent = $@"<html>
                                <body>
                                    <h2>Nouveau message pour Vita'MOUV</h2>
                                    <p><strong>Nom :</strong> {newEmail.FirstName} {newEmail.LastName}</p>
                                    <p><strong>Email :</strong> {newEmail.Email}</p>
                                    <p><strong>Statut :</strong> {newEmail.Status}</p>
                                    {(string.IsNullOrEmpty(newEmail.Institute) ? "" : $"<p><strong>Institut :</strong> {newEmail.Institute}</p>")}
                                    <p><strong>Ville :</strong> {newEmail.Town}</p>
                                    <hr />
                                    {(string.IsNullOrEmpty(newEmail.Subject) ? "" : $"<p><strong>Sujet :</strong> {newEmail.Subject}</p>")}
                                    <p>{newEmail.Message}</p>   
                                    <hr />
                                    {(string.IsNullOrEmpty(newEmail.Phone) ? "" : $"<p><strong>Téléphone :</strong> {newEmail.Phone}</p>")}
                                    <hr />
                                    <p><strong>Date :</strong> {DateTime.Now:dd/MM/yyyy HH:mm}</p>
                                </body>
                            </html>"
                };

                //serialization du payload en JSON
                var jsonPayload = JsonSerializer.Serialize(payload);
                var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                //envoi de la requête POST à l'API de Brevo
                if (_httpClient.DefaultRequestHeaders.Contains("api-key"))
                    _httpClient.DefaultRequestHeaders.Remove("api-key");

                _httpClient.DefaultRequestHeaders.Add("api-key", apiKey);

                var response = await _httpClient.PostAsync("https://api.brevo.com/v3/smtp/email", content);

                if (response.IsSuccessStatusCode)
                {
                    var payloadConfirmation = new
                    {
                        sender = new
                        {
                            name = "Vitamouv",
                            email = "admin.vitamouv@proton.me"
                        },
                        to = new[]
                        {
                        new {email = newEmail.Email }
                        },
                        subject = "Merci pour votre message !",
                        htmlContent = $@"<html>
                                <body>
                                    <p>Bonjour {newEmail.FirstName} {newEmail.LastName}</p>
                                    <br>
                                    <p>J'ai bien reçu votre message et je vous remercie de votre intérêt.</p>
                                    <p>Je reviendrai vers vous dans les plus brefs délais.</p>
                                    <br> 
                                    <p>Bien cordialement<p>
                                    <p>Nelly</p>
                                    <p>Vita'MOUV</p>
                                </body>
                            </html>"
};
                    var jsonPayloadConfirmation = JsonSerializer.Serialize(payloadConfirmation);
                    var contentConfirmation = new StringContent(jsonPayloadConfirmation, System.Text.Encoding.UTF8, "application/json");

                    if (_httpClient.DefaultRequestHeaders.Contains("api-key"))
                        _httpClient.DefaultRequestHeaders.Remove("api-key");

                    _httpClient.DefaultRequestHeaders.Add("api-key", apiKey);

                    var confirmationResponse = await _httpClient.PostAsync("https://api.brevo.com/v3/smtp/email", contentConfirmation);
                }
                
            return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BREVO ERROR: {ex.Message}" );
                return false;
            }


        }
    }
}

