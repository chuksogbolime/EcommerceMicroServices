using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceMicroServices.Api.product.Core.Interfaces;
using EcommerceMicroServices.Api.product.Core.Models;
using EcommerceMicroServices.Api.product.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EcommerceMicroServices.Api.product.Infrastructure.Data
{
    public class ProductQuery : IProductQuery
    {
        readonly ProductsDbContext _dbContext;
        readonly ILogger<ProductQuery> _logger;
        readonly IMapper _mapper;
        
        public ProductQuery(ProductsDbContext dbContext, ILogger<ProductQuery> logger, IMapper mapper, IProductCommand command)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            

            command.SeedData();
        }

        public async Task<(bool IsSuccess, IEnumerable<ProductModel> Product, string ErrorMessage)> GetAll()
        {
            try
            {
                var result = await _dbContext.Products.ToListAsync();
                if (result != null && result.Any())
                {
                    var products = _mapper.Map<IEnumerable<ProductModel>>(result);
                    return (true, products, null);
                }
                return (false, null, "No product found");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
            
        }
    }
}
