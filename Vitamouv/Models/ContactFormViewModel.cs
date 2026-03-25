using System.ComponentModel.DataAnnotations;

//création d'un viewModel pour le formulaire de contact, avec 
//ajout de DataAnnotations de validation pour les champs requis et les formats d'entrée
//permet d'avoir un formulaire fortement typé et de valider les données avant de les traiter

namespace Vitamouv.Models
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "Veuillez renseigner votre status.")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner votre prénom.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner votre nom de famille.")]
        public required string LastName { get; set; }

        public string? Institute { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner votre localité.")]
        public required string Town  { get; set; }

        [RegularExpression(
        @"^(?:(?:\+|00)33[1-9]\d{8}|0[1-9]\d{8}|(?:\+|00)352\d{6,9})$",
        ErrorMessage = "Numéro de téléphone non valide.")]   
        public string? Phone { get; set; }
        
        [EmailAddress(ErrorMessage = "Adresse e-mail non valide.")]
        [Required(ErrorMessage = "Veuillez renseigner votre adresse e-mail.")]
        public required string Email { get; set; }

        public string? Subject { get; set; }

        [Required(ErrorMessage = "Veuillez ajouter un message.")]
        public required string Message { get; set; }
    }
}