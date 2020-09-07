using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.product.Core.Models;

namespace EcommerceMicroServices.Api.product.Core.Interfaces
{
    public interface IProductQuery
    {
        Task<(bool IsSuccess, IEnumerable<ProductModel> Products, string ErrorMessage)> GetAllAsync();

        Task<(bool IsSuccess, ProductModel Product, string ErrorMessage)> GetSingleByIdAsync(int id);
    }
}
