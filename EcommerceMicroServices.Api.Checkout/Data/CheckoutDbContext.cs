using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMicroServices.Api.Checkout.Data
{
    public class CheckoutDbContext : DbContext
    {
        public CheckoutDbContext(DbContextOptions options) :base(options)
        {
            //seed data
            if (!this.Checkouts.Any())
            {
                this.Checkouts.Add(new Entities.Checkout
                {
                    Id = 1,
                    CustomerId = 1,
                    HasPaid = true,
                    OrderId = 1
                });

                this.Checkouts.Add(new Entities.Checkout
                {
                    Id = 2,
                    CustomerId = 2,
                    HasPaid = true,
                    OrderId = 2
                });

                this.SaveChanges();
            }
        }
        public DbSet<Entities.Checkout> Checkouts { get; set;  }
    }
}
