using System;
using EcommerceMicroService.Api.Search.Core.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace EcommerceMicroService.Api.Search.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService orderService;
        private readonly IProductsService productsService;
        readonly ICheckoutService checkoutService;
        private readonly ICustomerService customerService;

        public SearchService(IOrderService orderService, IProductsService productsService, ICheckoutService checkoutService, ICustomerService customerService)
        {
            this.orderService = orderService;
            this.productsService = productsService;
            this.checkoutService = checkoutService;
            this.customerService = customerService;
        }

        public async Task<(bool IsSuccess, dynamic Result, string ErrorMessage)> GetResultAsync(int customerId)
        {
            var customerResult = await customerService.GetAsync(customerId);
            var orderResult = await orderService.GetCustomerOrdersAsync(customerId);
            var productResult = await productsService.GetProductsAsync();
            var checkourResult = await checkoutService.GetCustomerCheckoutAsync(customerId);
            string message = customerResult.ErrorMessage;
            if (customerResult.IsSuccess)
            {
                if (orderResult.IsSuccess)
                {
                    foreach (var order in orderResult.Result)
                    {
                        foreach (var item in order.Items)
                        {
                            item.ProductName = productResult.Result?.FirstOrDefault(o => o.Id == item.ProductId)?.Name;
                        }
                        order.Checkout = checkourResult.Checkouts?.Where(o => o.OrderId == order.OrderId).FirstOrDefault();
                    }
                    customerResult.Customer.Orders = orderResult.Result;
                }
                
                
                var response = new
                {
                    customerResult.Customer
                };
                return (true, response, null);
            }
            return (false, null, customerResult.ErrorMessage);
        }
    }
}
