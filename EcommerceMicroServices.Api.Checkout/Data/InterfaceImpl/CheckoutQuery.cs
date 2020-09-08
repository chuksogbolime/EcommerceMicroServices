using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Checkout.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EcommerceMicroServices.Api.Checkout.Data.InterfaceImpl
{
    public class CheckoutQuery : ICheckoutQuery
    {
        readonly CheckoutDbContext _dbContext;
        readonly ILogger<CheckoutQuery> _logger;
        public CheckoutQuery(CheckoutDbContext dbContext, ILogger<CheckoutQuery> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Entities.Checkout> Checkouts, string ErrorMessage)> GetAllAsync()
        {
            try
            {
                var result = await _dbContext.Checkouts.ToListAsync();
                if (result != null && result.Any())
                {
                    
                    return (true, result, null);
                }
                return (false, null, "No checkouts found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Entities.Checkout> Checkouts, string ErrorMessage)> GetByCustomerId(int customerId)
        {
            try
            {
                var result = await _dbContext.Checkouts.Where(o=>o.CustomerId==customerId).ToListAsync();
                if (result != null && result.Any())
                {

                    return (true, result, null);
                }
                return (false, null, "No checkout found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
