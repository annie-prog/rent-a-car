﻿using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RentACarDbContext
    {      
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Rents> Request { get; set; }

    }
    
}
