using System;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RentACarDbContext : IdentityDbContext<User, IdentityRole, string>
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

    }
    
}
