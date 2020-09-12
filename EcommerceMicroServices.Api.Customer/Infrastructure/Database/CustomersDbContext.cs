using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMicroServices.Api.Customer.Infrastructure.Database
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions options):base(options)
        {
            SeedData();
        }

        public DbSet<Core.Entities.Customer> Customers { get; set; }

        private void SeedData()
        {
            if (this != null && !this.Customers.Any())
            {
                this.Customers.Add(new Core.Entities.Customer
                {
                    Id = 1,
                    Address = "23 Block camp street VI",
                    Name = "Mike Perry"
                });
                this.Customers.Add(new Core.Entities.Customer
                {
                    Id = 2,
                    Address = "6 Block vali street VI",
                    Name = "Tony Wask"
                });
                this.Customers.Add(new Core.Entities.Customer
                {
                    Id = 3,
                    Address = "12 derry street Font",
                    Name = "John Mecury"
                });
                this.SaveChanges();
            }
        }
    }
}
