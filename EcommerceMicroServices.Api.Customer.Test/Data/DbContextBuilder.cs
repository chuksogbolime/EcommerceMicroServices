using System;
using EcommerceMicroServices.Api.Customer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMicroServices.Api.Customer.Test.Data
{
    public static class DbContextBuilder
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

        public static void SeedTestData(CustomersDbContext dbContext)
        {
            for(int i=1; i<=10; i++)
            {
                dbContext.Customers.Add(new Core.Entities.Customer
                {
                    Id = i,
                    Address = $"Address {i}",
                    Name = $"Name {i}"
                });
            }
            dbContext.SaveChanges();
        }
        
    }
}
