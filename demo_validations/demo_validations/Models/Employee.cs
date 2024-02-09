using System.ComponentModel.DataAnnotations;

namespace demo_validations.Models
{
    //Employee Class
    public class Employee : IValidatableObject
    {

        //  [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = " Email is required ")]
        [EmailAddress(ErrorMessage = " Invalid Email Format ")]
        public string Email { get; set; }

        [MinLength(5, ErrorMessage = "Employee id must be 5 digit number")]
        //Custom validation made EmpmembershipValidation.
        [EmpmembershipValidation]
        public string empmembership { get; set; }

        public int Contact { get; set; }

        //   [Range(3, 18)]
        public int Age { get; set; }

        public DateTime date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (date.Year < 2024)
                yield return new ValidationResult("Date is incorrect");

            if (Name.Equals("Ridham"))
                yield return new ValidationResult("Username not allowed with Ridham ");

            if (Name.Equals("Nilay"))
                yield return new ValidationResult("Username not allowed with Nilay");

        }
    }
}
