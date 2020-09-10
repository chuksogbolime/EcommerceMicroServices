using System;
using System.Threading.Tasks;

namespace EcommerceMicroService.Api.Search.Core.Interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic Result, string ErrorMessage)> GetResultAsync(int customerId);
    }
}
