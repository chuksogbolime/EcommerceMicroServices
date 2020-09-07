using System;
using System.Linq;
using EcommerceMicroServices.Api.Customer.Core.Interfaces;
using EcommerceMicroServices.Api.Customer.Infrastructure.Database;

namespace EcommerceMicroServices.Api.Customer.Infrastructure.Data
{
    public class CustomerCommand :ICustomerCommand
    {
        readonly CustomersDbContext _dbContext;
        public CustomerCommand(CustomersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            if(_dbContext !=null && !_dbContext.Customers.Any())
            {
                _dbContext.Customers.Add(new Core.Entities.Customer
                {
                    Id = 1,
                    Address = "23 Block camp street VI",
                    Name = "Mike Perry"
                });
                _dbContext.Customers.Add(new Core.Entities.Customer
                {
                    Id = 2,
                    Address = "6 Block vali street VI",
                    Name = "Tony Wask"
                });
                _dbContext.Customers.Add(new Core.Entities.Customer
                {
                    Id = 3,
                    Address = "12 derry street Font",
                    Name = "John Mecury"
                });
                _dbContext.SaveChanges();
            }
        }
    }
}
