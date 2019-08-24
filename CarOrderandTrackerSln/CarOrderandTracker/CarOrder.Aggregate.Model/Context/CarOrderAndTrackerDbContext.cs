
using CarOrder.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarOrder.Domain.Context
{
    public class CarOrderAndTrackerDbContext : DbContext
    {

        public CarOrderAndTrackerDbContext()
        {
        }
        public CarOrderAndTrackerDbContext(DbContextOptions<CarOrderAndTrackerDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database = CarOrderandTrackerDB; Trusted_Connection = true");
        }

    }


}


