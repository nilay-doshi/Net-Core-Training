using demo_validations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Cache;

namespace demo_crud.Controllers
{

    
    //Custom validation
    //public class EmpmembershipValidation : ValidationAttribute
    //{
        
    //    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    //    {
    //        var employee = validationContext.ObjectInstance as Employee;
    //        if (employee?.empmembership.ToLower() == "trial")
    //            return new ValidationResult("Not Allowed");
    //        return ValidationResult.Success;
    //    }
    //}

   // Fluent Validation
    //public class EmployeeFluentValidation : AbstractValidator<Employee>
    //{
    //    public EmployeeFluentValidation()
    //    {
    //        RuleFor(e => e.Name).NotNull().NotEmpty().WithMessage("Name Must not be null or empty.");
    //        RuleFor(e => e.Email).EmailAddress().WithMessage("Enter a valid email address.");
    //        RuleFor(e => e.Age).GreaterThan(3).LessThan(18).WithMessage("Enter age between 3 to 18");
    //    }
    //}

    ////Employee Class
    //public class Employee : IValidatableObject
    //{

    //  //  [Required(ErrorMessage = "Name is required")]
    //    public string Name { get; set; }

    //    [Required(ErrorMessage = " Email is required ")]
    //    [EmailAddress(ErrorMessage = " Invalid Email Format ")]
    //    public string Email { get; set; }

    //    [MinLength(5, ErrorMessage = "Employee id must be 5 digit number")]
    //   //Custom validation made EmpmembershipValidation.
    //    [EmpmembershipValidation]
    //    public string empmembership { get; set; }

    //    public int Contact { get; set; }

    // //   [Range(3, 18)]
    //    public int Age { get; set; }

    //    public DateTime date { get; set; }

    //    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //    {
    //        if(date.Year < 2024)
    //            yield return new ValidationResult("Date is incorrect");
   
    //        if(Name.Equals("Ridham"))
    //            yield return new ValidationResult("Username not allowed with Ridham ");
   
    //        if (Name.Equals("Nilay"))
    //            yield return new ValidationResult("Username not allowed with Nilay");

    //    }
    //}

        [Route("api/[controller]")]
        [ApiController]
        public class EmployeeController : Controller
        {

        private static List<Employee> employee = new List<Employee>()
        {
            new Employee {Name = "Nilay", empmembership = "Hello", Email = "", Contact = 9611, Age = 21 }
        };

        [HttpGet]
        public ActionResult<List<string>> Getemployees()
        {
            return Ok(employee);
        }

        [HttpGet("[Action]")]
        public ActionResult<string> GetemployeesByIndex([FromHeader] int id)
        {
            return Ok(employee.ElementAt(id));
        }

        [HttpPut("")]
        public ActionResult UpdateEmployee(int id ,[FromQuery] Employee updatedEmployee)
        {
            employee[id] = updatedEmployee;
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddFruit([FromBody] Employee newEmployee) 
        {
            employee.Add(newEmployee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFruit(int id)
        {
            employee.RemoveAt(id);
            return Ok(employee);
        }

        
    }
}
