using System;
using EcommerceMicroServices.Api.Orders.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMicroServices.Api.Orders.Tests.Unit.Data
{
    public static class DbContextBuilder
    {
        public static OrdersDbContext InitContextWithInMemoryDbSupport()
        {
            var options = new DbContextOptionsBuilder<OrdersDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var _dbContext = new OrdersDbContext(options);
            _dbContext.Database.EnsureCreated();

            return _dbContext;
        }

        public static OrdersDbContext InitEmptyContext() => null;
    }
}
