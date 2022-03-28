using System;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RentACarDbContext : DbContext
    {      
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Rents> Rents { get; set; }

        public RentACarDbContext()
        {

        }

        public RentACarDbContext(DbContextOptions<RentACarDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=RentACarDb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Username = "user",
                    Password = "user",
                    FirstName = "User",
                    LastName = "User",
                    PersonalNumber = "0987654321",
                    PhoneNumber = "0882750588",
                    Email = "user@gmail.org",
                    Role = User.RoleEnum.User
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Username = "manager",
                    Password = "manager",
                    FirstName = "Manager",
                    LastName = "Manager",
                    PersonalNumber = "0987654321",
                    PhoneNumber = "0882750588",
                    Email = "manager@gmail.org",
                    Role = User.RoleEnum.Manager
                }
            );
            modelBuilder.Entity<User>()
               .HasIndex(user => new { user.Username, user.Password })
               .IsUnique(true);
            modelBuilder.Entity<Rents>().HasOne(u => u.User).WithMany().HasForeignKey(p => p.User);
            modelBuilder.Entity<Rents>().HasOne(c => c.Car).WithMany().HasForeignKey(c => c.Car);
        }

    }
    
}
