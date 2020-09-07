using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Customer.Core.Interfaces;
using EcommerceMicroServices.Api.Customer.Core.Models;
using EcommerceMicroServices.Api.Customer.Infrastructure.Database;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EcommerceMicroServices.Api.Customer.Infrastructure.Data
{
    public class CustomerQuery :ICustomerQuery
    {
        readonly CustomersDbContext _dbContext;
        readonly ILogger<CustomerQuery> _logger;
        readonly IMapper _mapper;
        public CustomerQuery(CustomersDbContext dbContext, ICustomerCommand command, ILogger<CustomerQuery> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            command.SeedData();
        }

        public async Task<(bool IsSuccess, IEnumerable<CustomerModel> Customers, string ErrorMessage)> GetAllAsync()
        {
            try
            {
                var result = await _dbContext.Customers.ToListAsync();
                if (result != null && result.Any())
                {
                    IEnumerable<CustomerModel> customers = _mapper.Map<IEnumerable<CustomerModel>>(result);
                    return (true, customers, null);
                }
                return (false, null, "No customer found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, CustomerModel Customer, string ErrorMessage)> GetSingleByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Customers.Where(o => o.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    CustomerModel customer = _mapper.Map<CustomerModel>(result);
                    return (true, customer, null);
                }
                return (false, null, $"Customer with Id:{id} was not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
