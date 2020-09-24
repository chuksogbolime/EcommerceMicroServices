using System;
using EcommerceMicroServices.Api.Orders.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EcommerceMicroServices.Api.Orders.Infrastructure.Database
{
    public class OrdersDbContext :DbContext
    {
        public OrdersDbContext(DbContextOptions options):base(options)
        {
            SeedData();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        private void SeedData()
        {
            if (this != null)
            {

                SeedOrder();
                SeedOrderItem();

                this.SaveChanges();
            }
        }

        private void SeedOrder()
        {
            if (!this.Orders.Any())
            {
                this.Orders.Add(new Core.Entities.Order
                {
                    OrderId = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.Now,
                    Total = 30
                });
                this.Orders.Add(new Core.Entities.Order
                {
                    OrderId = 2,
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                    Total = 10
                });
                this.Orders.Add(new Core.Entities.Order
                {
                    OrderId = 3,
                    CustomerId = 4,
                    OrderDate = DateTime.Now,
                    Total = 100
                });
            }
        }

        private void SeedOrderItem()
        {
            if (!this.OrderItems.Any())
            {
                this.OrderItems.Add(new Core.Entities.OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 5,
                    UnitPrice = 200.06M
                });

                this.OrderItems.Add(new Core.Entities.OrderItem
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 2,
                    Quantity = 10,
                    UnitPrice = 500.00M
                });
                this.OrderItems.Add(new Core.Entities.OrderItem
                {
                    Id = 3,
                    OrderId = 2,
                    ProductId = 4,
                    Quantity = 30,
                    UnitPrice = 10000.00M
                });
                this.OrderItems.Add(new Core.Entities.OrderItem
                {
                    Id = 4,
                    OrderId = 3,
                    ProductId = 1,
                    Quantity = 5,
                    UnitPrice = 600.00M
                });
            }
        }
    }
}
