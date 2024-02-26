using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TEAMPROJECT.Models;

public partial class TeamprojectContext : DbContext
{
    public TeamprojectContext()
    {
    }

    public TeamprojectContext(DbContextOptions<TeamprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HC7CRF0\\SQLEXPRESS;Database=TEAMPROJECT;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__USER_LOG__A9D10535AC25AE8F");

            entity.ToTable("USER_LOGIN");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Password)
                .HasMaxLength(8000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__USER_REG__A9D10535BE672EC5");

            entity.ToTable("USER_REGISTRATION");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FlagCouunt).HasDefaultValue(0);
            entity.Property(e => e.FlagRole).HasDefaultValue(0);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
