using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceMicroServices.Api.Orders.Core.Interfaces
{
    public interface IQuery<T>
    {
        Task<(bool IsSuccess, IEnumerable<T> Result, string ErrorMessage)> GetAllAsync();

        Task<(bool IsSuccess, T Result, string ErrorMessage)> GetSingleByIdAsync(int id);
    }
}
