using System.ComponentModel.DataAnnotations;

namespace TEAMPROJECT.Models;

public partial class UserRegistration
{
    public int Id { get; set; }

    [EmailAddress(ErrorMessage ="Enter valid email")]
    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public int? FlagRole { get; set; }

    public int? FlagCouunt { get; set; }
}
