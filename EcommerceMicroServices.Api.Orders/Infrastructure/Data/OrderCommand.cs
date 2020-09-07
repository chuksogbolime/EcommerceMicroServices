using System;
using System.Linq;
using EcommerceMicroServices.Api.Orders.Core.Interfaces;
using EcommerceMicroServices.Api.Orders.Infrastructure.Database;

namespace EcommerceMicroServices.Api.Orders.Infrastructure.Data
{
    public class OrderCommand :IOrderCommand
    {
        readonly OrdersDbContext _dbContext;
        public OrderCommand(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            if(_dbContext !=null && !_dbContext.Orders.Any())
            {
                _dbContext.Orders.Add(new Core.Entities.Order
                {
                    OrderId = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.Now,
                    Total = 30
                });
                _dbContext.Orders.Add(new Core.Entities.Order
                {
                    OrderId = 2,
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                    Total = 10
                });
                _dbContext.Orders.Add(new Core.Entities.Order
                {
                    OrderId = 3,
                    CustomerId = 4,
                    OrderDate = DateTime.Now,
                    Total = 100
                });
                _dbContext.SaveChanges();
            }
        }
    }
}
