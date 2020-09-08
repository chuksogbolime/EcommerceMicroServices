using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceMicroServices.Api.Checkout.Data.Interfaces
{
    public interface ICheckoutQuery
    {
        Task<(bool IsSuccess, IEnumerable<Entities.Checkout> Checkouts, string ErrorMessage)> GetAllAsync();
        Task<(bool IsSuccess, IEnumerable<Entities.Checkout> Checkouts, string ErrorMessage)> GetByCustomerId(int customerId);
    }
}
