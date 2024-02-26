using System.ComponentModel.DataAnnotations;

namespace Team_Project.Models
{
    public class UserLogin
    {
        public Guid id { get; set; }

        [EmailAddress(ErrorMessage = "Email address is required")]
        [Key]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        public string Password { get; set; } 
    }
}
