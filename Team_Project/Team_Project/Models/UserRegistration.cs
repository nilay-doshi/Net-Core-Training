using System.ComponentModel.DataAnnotations;

namespace Team_Project.Models
{
    public class UserRegistration
    {
        public Guid Id { get; set; }
        
        [EmailAddress(ErrorMessage = "Email address is required")]
        [Key]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "FirstName is compulsory")]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        
        [Required(ErrorMessage = "LastName is compulsory")]
        [MaxLength(50)] 
        public string LastName { get; set; } = null!;

        [Phone(ErrorMessage = "Contact Number is compulsory")]
        [MaxLength(50)]
        public string ContactNumber { get; set; } = null!;

        public DateOnly Dob { get; set; }

        public int? FlagRole { get; set; } = 0;

        public int? FlagCouunt { get; set; } = 0;
    }
}
