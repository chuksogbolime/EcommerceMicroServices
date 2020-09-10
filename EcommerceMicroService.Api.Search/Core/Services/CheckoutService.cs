using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using EcommerceMicroService.Api.Search.Core.Models;
using Microsoft.Extensions.Logging;

namespace EcommerceMicroService.Api.Search.Core.Services
{
    public class CheckoutService :Interfaces.ICheckoutService
    {
        private readonly ILogger<ProductsServices> logger;
        private readonly IHttpClientFactory factory;

        public CheckoutService(IHttpClientFactory factory, ILogger<ProductsServices> logger)
        {
            this.logger = logger;
            this.factory = factory;
        }

        public async Task<(bool IsSuccess, IEnumerable<Checkout> Checkouts, string ErrorMessage)> GetCustomerCheckoutAsync(int customerId)
        {
            try
            {
                var client = factory.CreateClient(Common.HttpClientName.CHECKOUTS);
                var resposne = await client.GetAsync($"api/checkouts/{customerId}");
                if (resposne.IsSuccessStatusCode)
                {
                    var content = await resposne.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Checkout>>(content, options);
                    return (true, result, null);
                }
                return (false, null, "No record found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
