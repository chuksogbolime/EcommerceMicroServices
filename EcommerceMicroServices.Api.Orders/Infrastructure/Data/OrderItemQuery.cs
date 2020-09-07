using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceMicroServices.Api.Orders.Core.Interfaces;
using EcommerceMicroServices.Api.Orders.Core.Models;
using EcommerceMicroServices.Api.Orders.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EcommerceMicroServices.Api.Orders.Infrastructure.Data
{
    public class OrderItemQuery :IOrderItemQuery
    {
        readonly OrdersDbContext _dbContext;
        readonly ILogger<OrderItemQuery> _logger;
        readonly IMapper _mapper;

        public OrderItemQuery(OrdersDbContext dbContext, ILogger<OrderItemQuery> logger, IMapper mapper, IOrderCommand orderCommand, IOrderItemCommand orderItemCommand)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            //orderCommand.SeedData();
            //orderItemCommand.SeedData();

        }
       

        public async Task<(bool IsSuccess, IEnumerable<OrderItemModel> Result, string ErrorMessage)> GetAllAsync()
        {
            try
            {
                var result = await _dbContext.OrderItems.ToListAsync();
                if (result != null && result.Any())
                {
                    IEnumerable<OrderItemModel> items = _mapper.Map<IEnumerable<OrderItemModel>>(result);
                    return (true, items, null);
                }
                return (false, null, "No order item found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, OrderItemModel Result, string ErrorMessage)> GetSingleByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.OrderItems.Where(o => o.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    OrderItemModel item = _mapper.Map<OrderItemModel>(result);
                    return (true, item, null);
                }
                return (false, null, $"Item with Id:{id} was not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
