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
    public class OrderQuery : IOrderQuery
    {
        readonly OrdersDbContext _dbContext;
        readonly ILogger<OrderQuery> _logger;
        readonly IMapper _mapper;

        public OrderQuery(OrdersDbContext dbContext, ILogger<OrderQuery> logger, IMapper mapper, IOrderCommand orderCommand, IOrderItemCommand orderItemCommand)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            orderCommand.SeedData();
            orderItemCommand.SeedData();
        }


        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Result, string ErrorMessage)> GetAllAsync()
        {
            try
            {
                var result = await _dbContext.Orders.ToListAsync();
                if (result != null && result.Any())
                {
                    IEnumerable<OrderModel> orders = _mapper.Map<IEnumerable<OrderModel>>(result);
                    return (true, orders, null);
                }
                return (false, null, "No order found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Orders, string ErrorMessage)> GetOrdersByCustomerIdAsync(int customerId)
        {
            try
            {
                var result = await _dbContext.Orders.Where(o=>o.CustomerId==customerId).Include(o=>o.Items).ToListAsync();
                if (result != null && result.Any())
                {
                    IEnumerable<OrderModel> orders = _mapper.Map<IEnumerable<OrderModel>>(result);
                    return (true, orders, null);
                }
                return (false, null, "No order found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, OrderModel Result, string ErrorMessage)> GetSingleByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    OrderModel item = _mapper.Map<OrderModel>(result);
                    return (true, item, null);
                }
                return (false, null, $"Order with Id:{id} was not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
