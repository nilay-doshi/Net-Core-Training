using demo_crud.Controllers;
using System.ComponentModel.DataAnnotations;

namespace demo_validations.Models
{
    //Custom Validation
    public class EmpmembershipValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var employee = validationContext.ObjectInstance as Employee;
            if (employee?.empmembership.ToLower() == "trial")
                return new ValidationResult("Not Allowed");
            return ValidationResult.Success;
        }
    }
}
