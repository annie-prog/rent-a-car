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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if (this.Users.FirstOrDefaultAsync() != null)
            //{

            //    modelBuilder.Entity<User>().HasData(initialUser);
            //    IdentityRole<string> adminRole = await this.Roles.FirstOrDefaultAsync(role => role.Name == "Admin");
            //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> {RoleId = adminRole.Id, UserId = initialUser.Id});
            //}

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            User initialUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                Email = "admin@admin.admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            initialUser.PasswordHash = passwordHasher.HashPassword(initialUser, "admin123");

            modelBuilder.Entity<User>().HasData(initialUser);
            string[] roles = { "Admin", "Employee" };

            foreach (string role in roles)
            {
                IdentityRole newRole = new IdentityRole(role);
                newRole.Id = Guid.NewGuid().ToString();
                modelBuilder.Entity<IdentityRole>().HasData(newRole);
                IdentityUserRole<string> userRole = new IdentityUserRole<string>();
                userRole.UserId = initialUser.Id;
                userRole.RoleId = newRole.Id;
                modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
            }

            modelBuilder.Entity<Rents>().HasKey(rents => rents.Id);
            modelBuilder.Entity<Car>().HasKey(car => car.Id);
            modelBuilder.Entity<Rents>().HasOne(rents => rents.User);
            modelBuilder.Entity<Rents>().HasOne(rents => rents.Car);

            base.OnModelCreating(modelBuilder);
        }

    }
    
}
