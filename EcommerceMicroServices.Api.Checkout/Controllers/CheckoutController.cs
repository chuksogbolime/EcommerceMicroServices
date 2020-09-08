using System;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Checkout.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EcommerceMicroServices.Api.Checkout.Controllers
{
    [ApiController]
    [Route("api/checkouts")]
    public class CheckoutController : ControllerBase
    {
        readonly IMediator _mediator;
        public CheckoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllCheckoutQuery());
            if (result !=null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("customerId")]
        public async Task<IActionResult> GetByCustomerIdAsync(int customerId)
        {
            var result = await _mediator.Send(new GetCheckoutByCustomer(customerId));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]Models.ApiRequest.CheckoutRequest request)
        {
            var command = new Command.CreateCheckoutCommand(request.CustomerId, request.OrderId, request.HasPaid);
            var result = await _mediator.Send(command);
            if (result.IsSuccessful)
            {
                return Ok(result.CheckoutId);
            }
            return NoContent();
        }
    }
}
