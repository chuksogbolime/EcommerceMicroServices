using System;
using System.Threading.Tasks;

namespace EcommerceMicroService.Api.Search.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<(bool IsSuccess, Models.Customer Customer, string ErrorMessage)> GetAsync(int customerId);
    }
}
