using CarOrder.Aggregate.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarOrder.Aggregate.Model.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Orderitem = 152223333,
                Orderitemmodel = "Desire - Zxi",
                Engine = "Petrol",
                Make = "AA",
                Year = "Jan- 2019"

            }, new Order
            {
                Orderitem = 1522233855,
                Orderitemmodel = "Desire - Zxi+",
                Engine = "Diesel",
                Make = "MA",
                Year = "Jan- 2018"
            });
        }


    }

}
