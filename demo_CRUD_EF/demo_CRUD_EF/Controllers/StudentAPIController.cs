using demo_CRUD_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
