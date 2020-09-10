using System;
using EcommerceMicroService.Api.Search.Core.Interfaces;
using System.Threading.Tasks;

namespace EcommerceMicroService.Api.Search.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService orderService;

        public SearchService(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<(bool IsSuccess, dynamic Result, string ErrorMessage)> GetResultAsync(int customerId)
        {
            var result = await orderService.GetCustomerOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                var response = new
                {
                    Orders = result.Result
                };
                return (true, response, null);
            }
            return (false, null, result.ErrorMessage);
        }
    }
}
