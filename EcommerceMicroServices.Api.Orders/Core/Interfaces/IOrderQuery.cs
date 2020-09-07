using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Orders.Core.Models;

namespace EcommerceMicroServices.Api.Orders.Core.Interfaces
{
    public interface IOrderQuery :IQuery<OrderModel>
    {
        Task<(bool IsSuccess, IEnumerable<OrderModel> Orders, string ErrorMessage)> GetOrdersByCustomerIdAsync(int customerId);
    }
}
