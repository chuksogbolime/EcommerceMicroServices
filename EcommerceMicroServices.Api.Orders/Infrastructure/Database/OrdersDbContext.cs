using System;
using EcommerceMicroServices.Api.Orders.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMicroServices.Api.Orders.Infrastructure.Database
{
    public class OrdersDbContext :DbContext
    {
        public OrdersDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
