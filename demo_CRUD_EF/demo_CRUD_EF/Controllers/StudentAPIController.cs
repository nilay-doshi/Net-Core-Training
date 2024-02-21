using demo_CRUD_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo_CRUD_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentDbContext studentDB;

        public StudentAPIController(StudentDbContext studentDB)
        {
            this.studentDB = studentDB;
        }

        [HttpGet("GetStudentdetails")]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await studentDB.Students.ToListAsync();
            return Ok(data);
        }

        [HttpGet("[Action]/{id}")]
        public async Task<ActionResult<Student>> GetStudentsById(int id)
        {
            var student = await studentDB.Students.FindAsync(id);
            
            if(student == null)
                return NotFound("Student id not found");
            
            return Ok(student);
        }

        [HttpPost("Create Students")]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            await studentDB.Students.AddAsync(student);
            await studentDB.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id,Student student)
        {
            if(id != student.Id)
            {
                return BadRequest();
            }
            studentDB.Entry(student).State = EntityState.Modified;
            await studentDB.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<Student>> DeleteStudent(int id )
        {
            var std = await studentDB.Students.FindAsync(id);
            if(std == null)
                return NotFound();
             studentDB.Students.Remove(std);
            await studentDB.SaveChangesAsync();
            return Ok();
        }



    }
}
