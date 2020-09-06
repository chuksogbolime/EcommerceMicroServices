using System;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.product.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMicroServices.Api.product.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        readonly IProductQuery _query;
        public ProductsController(IProductQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _query.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }
            return NotFound();
        }
    }
}
