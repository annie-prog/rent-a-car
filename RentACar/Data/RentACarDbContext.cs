using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RentACarDbContext : DbContext
    {      
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Rents> Rents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=RentACarDb;Integrated Security=true;");
            }
        }

    }
    
}
