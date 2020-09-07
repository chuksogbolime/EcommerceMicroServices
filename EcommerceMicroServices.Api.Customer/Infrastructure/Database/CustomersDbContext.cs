using System;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMicroServices.Api.Customer.Infrastructure.Database
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Core.Entities.Customer> Customers { get; set; }
    }
}
