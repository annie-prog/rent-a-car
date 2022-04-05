using System;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RentACarDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Rents> Rents { get; set; }

        public RentACarDbContext(DbContextOptions<RentACarDbContext> dbContextOptions) : base(dbContextOptions)
        {

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

            base.OnModelCreating(modelBuilder);
            //string[] roles = { "Admin", "Employee" };

            //foreach (string role in roles)
            //{
            //    IdentityRole roleToCheck = await this.Roles.FirstOrDefaultAsync(roleToCheck => roleToCheck.Name == role);
            //    if (roleToCheck == null)
            //    {
            //        //this.Roles.Add(new IdentityRole(role));
            //        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole(role));
            //    }
            //}

            //PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            //User initialUser = new User();
            //initialUser.Id = Guid.NewGuid().ToString();
            //initialUser.UserName = "admin";
            //initialUser.PasswordHash = passwordHasher.HashPassword(initialUser, "admin");


            //if (this.Users.FirstOrDefaultAsync() != null)
            //{

            //    modelBuilder.Entity<User>().HasData(initialUser);
            //    IdentityRole<string> adminRole = await this.Roles.FirstOrDefaultAsync(role => role.Name == "Admin");
            //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> {RoleId = adminRole.Id, UserId = initialUser.Id});
            //}

            modelBuilder.Entity<Rents>().HasOne(rents => rents.User);
            modelBuilder.Entity<Rents>().HasOne(rents => rents.Car);

            modelBuilder.Entity<Car>().HasData(new Car()
            {
                Id = 1,
                Brand = "Trabant"
            }) ;

        }

    }
    
}
