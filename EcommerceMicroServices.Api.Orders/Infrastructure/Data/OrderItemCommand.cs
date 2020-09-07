using System;
using System.Linq;
using EcommerceMicroServices.Api.Orders.Core.Interfaces;
using EcommerceMicroServices.Api.Orders.Infrastructure.Database;

namespace EcommerceMicroServices.Api.Orders.Infrastructure.Data
{
    public class OrderItemCommand : IOrderItemCommand
    {
        readonly OrdersDbContext _dbContext;
        public OrderItemCommand(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            if (_dbContext != null && !_dbContext.OrderItems.Any())
            {
                _dbContext.OrderItems.Add(new Core.Entities.OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 5,
                    UnitPrice = 200.06M
                });

                _dbContext.OrderItems.Add(new Core.Entities.OrderItem
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 2,
                    Quantity = 10,
                    UnitPrice = 500.00M
                });
                _dbContext.OrderItems.Add(new Core.Entities.OrderItem
                {
                    Id = 3,
                    OrderId = 2,
                    ProductId = 4,
                    Quantity = 30,
                    UnitPrice = 10000.00M
                });
                _dbContext.OrderItems.Add(new Core.Entities.OrderItem
                {
                    Id = 4,
                    OrderId = 3,
                    ProductId = 1,
                    Quantity = 5,
                    UnitPrice = 600.00M
                });
                _dbContext.SaveChanges();
            }
        }
    }
}
