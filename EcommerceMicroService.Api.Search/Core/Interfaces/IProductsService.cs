using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace EcommerceMicroService.Api.Search.Core.Interfaces
{
    public interface IProductsService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Product> Result, string ErrorMessage)> GetProductsAsync();
    }
}
