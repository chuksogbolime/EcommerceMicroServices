using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using EcommerceMicroService.Api.Search.Core.Interfaces;
using EcommerceMicroService.Api.Search.Core.Models;
using Microsoft.Extensions.Logging;

namespace EcommerceMicroService.Api.Search.Core.Services
{
    public class CustomerService : ICustomerService
    {
        
        private readonly ILogger<CustomerService> logger;
        private readonly IHttpClientFactory factory;

        public CustomerService(IHttpClientFactory factory, ILogger<CustomerService> logger)
        {
            this.logger = logger;
            this.factory = factory;
        }

        public async Task<(bool IsSuccess, Customer Customer, string ErrorMessage)> GetAsync(int customerId)
        {
            try
            {
                var client = factory.CreateClient(Common.HttpClientName.CUSTOMER);
                var resposne = await client.GetAsync($"api/customers/{customerId}");
                if (resposne.IsSuccessStatusCode)
                {
                    var content = await resposne.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<Customer>(content, options);
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
