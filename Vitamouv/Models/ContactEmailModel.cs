using System.Globalization;

namespace Vitamouv.Models
{
    public class ContactEmailModel
    {   
        public required string Status { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Institute { get; set; }

        public required string Town { get; set; }

        public string? Phone { get; set; }
        public required string Email { get; set; }
        public string? Subject { get; set; }
        public required string Message { get; set; }
    }
}
