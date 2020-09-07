using System;
using EcommerceMicroServices.Api.Customer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMicroServices.Api.Customer.Test.Data
{
    public class DbContextBuilder
    {
        public static CustomersDbContext InitContextWithInMemoryDbSupport()
        {
            var options = new DbContextOptionsBuilder<CustomersDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var _dbContext = new CustomersDbContext(options);
            _dbContext.Database.EnsureCreated();

            return _dbContext;
        }

        public static CustomersDbContext InitEmptyContext() => null;
        
    }
}
