using Microsoft.EntityFrameworkCore;

namespace demo_EFCORE_CodeFirstApproach_MVC.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
             
        }

        public DbSet<Student> Students { get; set; }

    }
}
