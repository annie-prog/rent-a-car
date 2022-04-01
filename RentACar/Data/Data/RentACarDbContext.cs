using System;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RentACarDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Rents> Rents { get; set; }
        private UserManager<User> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }

        public RentACarDbContext()
        {
            //TODO: initialize UserManager and RoleManager
        }

        public RentACarDbContext(DbContextOptions<RentACarDbContext> dbContextOptions) : base(dbContextOptions)
        {
            //TODO: initialize UserManager and RoleManager
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=RentACar;Integrated Security=true;");
            }
        }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            string[] roles = { "Admin", "Employee" };

            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            User initialUser = new User
            {
                UserName = "admin",
                PasswordHash = "admin",
            };

            modelBuilder.Entity<User>().HasData(initialUser);
            await userManager.AddToRoleAsync(initialUser, roles[0]);

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Username = "user",
            //        Password = "user",
            //        FirstName = "User",
            //        LastName = "User",
            //        PersonalNumber = "0987654321",
            //        PhoneNumber = "0882750588",
            //        Email = "user@gmail.org",
            //        Role = User.RoleEnum.User
            //    }
            //);
            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Username = "manager",
            //        Password = "manager",
            //        FirstName = "Manager",
            //        LastName = "Manager",
            //        PersonalNumber = "0987654321",
            //        PhoneNumber = "0882750588",
            //        Email = "manager@gmail.org",
            //        Role = User.RoleEnum.Manager
            //    }
            //);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
               .HasIndex(user => new { user.UserName })
               .IsUnique(true);
            modelBuilder.Entity<Rents>().HasOne(rents => rents.User);
            modelBuilder.Entity<Rents>().HasOne(rents => rents.Car);
        }

    }
    
}
