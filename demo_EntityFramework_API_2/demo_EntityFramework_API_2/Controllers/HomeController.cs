using demo_EntityFramework_API_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo_EntityFramework_API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly EmployeeDbContext employeeDb;

        public HomeController(EmployeeDbContext employeeDb)
        {
            this.employeeDb = employeeDb;
        }

        [HttpGet("GetEmployeedetails")]
        public async Task<ActionResult<List<FEData>>> GetEmployee()
        {
            var res = await employeeDb.Employees.Join(employeeDb.Departments,
               x => x.DepartmentId, d => d.DepartmentId,
               (x, d) =>
               new FEData()
               {
                   EmployeeName = x.EmployeeName,
                   EmployeeGender = x.EmployeeGender,
                   EmployeeSalary = x.EmployeeSalary,
                   DepartmentName = d.DepartmentName
               }).ToListAsync();

            return res;
        }

        [HttpGet("GetDepartmentDetails")]
        public ActionResult<string> GetDepartmentName(int id)
        {
            var employee = employeeDb.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee.Department.DepartmentName;
        }


        [HttpGet("[Action]/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeesById(int id)
        {
            var employee = await employeeDb.Employees.FindAsync(id);

            if (employee == null)
                return NotFound("Employee id not found");

            return Ok(employee);
        }

        [HttpPost("Create Employee")]
        public async Task<ActionResult<Employee>> AddStudent(int id, Employee employee)
        {
            await employeeDb.Employees.AddAsync(employee);
            await employeeDb.SaveChangesAsync();

            return Ok();
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest();
            employeeDb.Entry(employee).State = EntityState.Modified;
            await employeeDb.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var std = await employeeDb.Employees.FindAsync(id);
            if (std == null)
                return NotFound();
            employeeDb.Employees.Remove(std);
            await employeeDb.SaveChangesAsync();    
            return Ok(" Data deleted successfully");
        }




    }
}
