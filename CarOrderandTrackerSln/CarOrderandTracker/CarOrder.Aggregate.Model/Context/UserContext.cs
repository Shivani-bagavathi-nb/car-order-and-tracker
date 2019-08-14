using CarOrder.Aggregate.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarOrder.Aggregate.Model.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                EmailId = "rkv@gmail.com",
                Password = "pass@word1"

            }, new User
            {
                EmailId = "shiv@gmail.com",
                Password = "pass@word2"
            });
        }

    }
}
