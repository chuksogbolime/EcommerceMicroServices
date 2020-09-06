using System;
using EcommerceMicroServices.Api.product.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMicroServices.Api.product.Infrastructure.Database
{
    public class ProductsDbContext: DbContext
    {
        public ProductsDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
