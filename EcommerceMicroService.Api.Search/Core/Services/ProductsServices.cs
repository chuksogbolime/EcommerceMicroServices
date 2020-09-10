using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EcommerceMicroService.Api.Search.Core.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace EcommerceMicroService.Api.Search.Core.Services
{
    public class ProductsServices :Interfaces.IProductsService
    {
        private readonly IHttpClientFactory factory;
        private readonly ILogger<ProductsServices> logger;

        public ProductsServices(IHttpClientFactory factory, ILogger<ProductsServices> logger)
        {
            this.factory = factory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Product> Result, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var client = factory.CreateClient(Common.HttpClientName.PRODUCTS);
                var resposne = await client.GetAsync("api/products");
                if (resposne.IsSuccessStatusCode)
                {
                    var content = await resposne.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);
                    return (true, result, null);
                }
                return (false, null, "No record found");
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
