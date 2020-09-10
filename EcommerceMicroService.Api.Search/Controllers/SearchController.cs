using System;
using System.Threading.Tasks;
using EcommerceMicroService.Api.Search.Core.Interfaces;
using EcommerceMicroService.Api.Search.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMicroService.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController:ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> GetOrderSearchResultAsync([FromBody] SearchItem searchItem)
        {
            var result = await searchService.GetResultAsync(searchItem.CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            return NotFound();
        }
    }
}
