using Microsoft.EntityFrameworkCore;
using teamproject_Repository.Models;

namespace teamproject_Repository
{

    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options)
        { }
        public DbSet<UserRegistration> Registration { get; set; }
        public DbSet<Coach> Coach { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>().HasData(
                new Coach
                {
                    Coachid = 1,
                    Email = "nilaydoshi@gmail.com",
                    FirstName = "Nilay",
                    LastName = "Doshi",
                    ContactNumber = "9033062657",
                    Dob = new DateOnly(1999, 01, 02),
                    FlagRole = 5
                }
               );

            base.OnModelCreating(modelBuilder);
        }

    }
}
