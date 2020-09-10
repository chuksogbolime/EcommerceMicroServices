using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroService.Api.Search.Core.Models;

namespace EcommerceMicroService.Api.Search.Core.Interfaces
{
    public interface ICheckoutService
    {
        Task<(bool IsSuccess, IEnumerable<Checkout> Checkouts, string ErrorMessage)> GetCustomerCheckoutAsync(int customerId); 
    }
}
