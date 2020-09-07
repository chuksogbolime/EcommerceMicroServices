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

        public async Task<(bool IsSuccess, IEnumerable<ProductModel> Products, string ErrorMessage)> GetAllAsync()
        {
            try
            {
                var result = await _dbContext.Products.ToListAsync();
                if (result != null && result.Any())
                {
                    IEnumerable<ProductModel> products = _mapper.Map<IEnumerable<ProductModel>>(result);
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

        public async Task<(bool IsSuccess, ProductModel Product, string ErrorMessage)> GetSingleByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Products.Where(o=>o.Id==id).FirstOrDefaultAsync();
                if (result != null)
                {
                    ProductModel product = _mapper.Map<ProductModel>(result);
                    return (true, product, null);
                }
                return (false, null, $"Product with Id:{id} was not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
