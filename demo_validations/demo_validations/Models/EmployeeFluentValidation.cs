using FluentValidation;
using demo_crud.Controllers;

namespace demo_validations.Models
{
    public class EmployeeFluentValidation : AbstractValidator<Employee>
    {
        public EmployeeFluentValidation()
        {
            RuleFor(e => e.Name).NotNull().NotEmpty().WithMessage("Name Must not be null or empty.");
            RuleFor(e => e.Email).EmailAddress().WithMessage("Enter a valid email address.");
            RuleFor(e => e.Age).GreaterThan(3).LessThan(18).WithMessage("Enter age between 3 to 18");
        }

    }
}
