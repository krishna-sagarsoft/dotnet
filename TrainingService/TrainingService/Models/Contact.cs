using System.ComponentModel.DataAnnotations;

namespace TrainingService.Models
{
    public class Contact
    {
        [Key]
        
        public int ContactId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
    }
}
