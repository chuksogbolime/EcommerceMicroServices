using System;
using EcommerceMicroServices.Api.product.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMicroServices.Api.Product.Tests.Infrastructure.Database
{
    public class ProductDbContextBuilder
    {
        public static ProductsDbContext InitContextWithInMemoryDbSupport()
        {
            var options = new DbContextOptionsBuilder<ProductsDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var _dbContext = new ProductsDbContext(options);
            _dbContext.Database.EnsureCreated();

            return _dbContext;
        }

        public static ProductsDbContext InitEmptyContext()
        {
            

            return null;
        }
    }
}
