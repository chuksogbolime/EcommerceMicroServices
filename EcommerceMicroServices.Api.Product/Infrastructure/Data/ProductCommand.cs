using System;
using System.Linq;
using EcommerceMicroServices.Api.product.Core.Interfaces;
using EcommerceMicroServices.Api.product.Infrastructure.Database;

namespace EcommerceMicroServices.Api.product.Infrastructure.Data
{
    public class ProductCommand : IProductCommand
    {
        readonly ProductsDbContext _dbContext;
        public ProductCommand(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            if (!_dbContext.Products.Any())
            {
                _dbContext.Products.Add(new Core.Entities.Product
                {
                    Id = 1,
                    Inventory = 20,
                    Name = "Table",
                    Price = 20000
                });
                _dbContext.Products.Add(new Core.Entities.Product
                {
                    Id = 2,
                    Inventory = 100,
                    Name = "Chair",
                    Price = 10000
                });
                _dbContext.Products.Add(new Core.Entities.Product
                {
                    Id = 3,
                    Inventory = 40,
                    Name = "Cup",
                    Price = 200
                });
                _dbContext.Products.Add(new Core.Entities.Product
                {
                    Id = 4,
                    Inventory = 200,
                    Name = "Plate",
                    Price = 400
                });

                _dbContext.SaveChanges();
            }
   
        }
    }
}
