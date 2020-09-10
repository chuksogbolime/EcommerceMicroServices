using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroService.Api.Search.Core.Models;

namespace EcommerceMicroService.Api.Search.Core.Interfaces
{
    public interface IOrderService
    {
        Task<(bool IsSuccess, IEnumerable<Order> Result, string ErrorMessage)> GetCustomerOrdersAsync(int customerId);
    }
}
