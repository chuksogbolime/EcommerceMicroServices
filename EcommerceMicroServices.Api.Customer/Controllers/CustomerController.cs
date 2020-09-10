using System;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Customer.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMicroServices.Api.Customer.Controllers
{
    [ApiController]
    [Route("api/Customers")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerQuery _query;
        public CustomerController(ICustomerQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _query.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        //[Route("GetSingleById/{id}")]
        public async Task<IActionResult> GetSingleById(int id)
        {
            var result = await _query.GetSingleByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }
    }
}
