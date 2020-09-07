using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Customer.Core.Models;

namespace EcommerceMicroServices.Api.Customer.Core.Interfaces
{
    public interface ICustomerQuery
    {
        Task<(bool IsSuccess, IEnumerable<CustomerModel> Customers, string ErrorMessage)> GetAllAsync();
        Task<(bool IsSuccess, CustomerModel Customer, string ErrorMessage)> GetSingleByIdAsync(int id);
    }
}
