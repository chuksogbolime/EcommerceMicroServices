using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using EcommerceMicroService.Api.Search.Core.Models;
using Microsoft.Extensions.Logging;

namespace EcommerceMicroService.Api.Search.Core.Services
{
    public class OrderService :Interfaces.IOrderService
    {
        public OrderService(IHttpClientFactory factory, ILogger<OrderService> logger)
        {
            _factory = factory;
            _logger = logger;
        }

        readonly IHttpClientFactory _factory;
        readonly ILogger<OrderService> _logger;

        public async Task<(bool IsSuccess, IEnumerable<Order> Result, string ErrorMessage)> GetCustomerOrdersAsync(int customerId)
        {
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                var client = _factory.CreateClient(Common.HttpClientName.ORDERS);
                
                var response = await client.GetAsync($"api/orders/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Order>>(content,options);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch(Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
