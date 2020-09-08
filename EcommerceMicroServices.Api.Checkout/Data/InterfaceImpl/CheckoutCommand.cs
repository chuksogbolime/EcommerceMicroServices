using System;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceMicroServices.Api.Checkout.Data.Interfaces;
using Microsoft.Extensions.Logging;

namespace EcommerceMicroServices.Api.Checkout.Data.InterfaceImpl
{
    public class CheckoutCommand : ICheckoutCommand
    {
        readonly CheckoutDbContext _dbContext;
        readonly ILogger<CheckoutCommand> _logger;
        readonly IMapper _mapper;
        public CheckoutCommand(CheckoutDbContext dbContext, ILogger<CheckoutCommand> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(bool IsSuccessful, int CheckoutId)> AddAsync(Models.CheckoutModel checkout)
        {
            try
            {
                var entity = _mapper.Map<Entities.Checkout>(checkout);
                _dbContext.Checkouts.Add(entity);
                await _dbContext.SaveChangesAsync();
                return (true, entity.Id); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, -1);
            }
        }
    }
}
