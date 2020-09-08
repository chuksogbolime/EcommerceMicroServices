using System;
using System.Threading.Tasks;

namespace EcommerceMicroServices.Api.Checkout.Data.Interfaces
{
    public interface ICheckoutCommand
    {
        Task<(bool IsSuccessful, int CheckoutId)> AddAsync(Models.CheckoutModel checkout);
    }
}
