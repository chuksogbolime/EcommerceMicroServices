using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Orders.Core.Interfaces;
using EcommerceMicroServices.Api.Orders.Core.Models;

namespace EcommerceMicroServices.Api.Orders.Core.UseCase
{
    public class OrderProvider : IOrderProvider
    {
        readonly IOrderQuery _query;
        public OrderProvider(IOrderCommand orderCommand, IOrderItemCommand orderItemCommand, IOrderQuery query)
        {
            _query = query;

            orderCommand.SeedData();
            orderItemCommand.SeedData();
        }

        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Orders, string ErrorMessage)> GetOrdersAsync()
        {
            return await _query.GetAllAsync();
        }

        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Orders, string ErrorMessage)> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _query.GetOrdersByCustomerIdAsync(customerId);
        }
    }
}
