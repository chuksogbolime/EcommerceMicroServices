using System;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Orders.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMicroServices.Api.Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController :ControllerBase
    {
        readonly IOrderProvider _orderProvider;
        public OrdersController(IOrderProvider orderProvider)
        {
            _orderProvider = orderProvider;
        }

        [HttpGet()]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await _orderProvider.GetOrdersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }

        [HttpGet("{customerId}")]
        //[Route("GetOrdersByCustomerIdAsync/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomerIdAsync(int customerId)
        {
            var result = await _orderProvider.GetOrdersByCustomerIdAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}
