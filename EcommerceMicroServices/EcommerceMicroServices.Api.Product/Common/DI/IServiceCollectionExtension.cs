using System;
using EcommerceMicroServices.Api.product.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using EcommerceMicroServices.Api.product.Core.Interfaces;
using EcommerceMicroServices.Api.product.Infrastructure.Data;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace EcommerceMicroServices.Api.product.Common.DI
{
    public static class IServiceCollectionExtension
    {
        public static void ConfigureInMemoryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ProductsDbContext>(options =>
            {
                options.UseInMemoryDatabase("ProductsDb");
            });
        }

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IProductCommand, ProductCommand>();
            services.AddScoped<IProductQuery, ProductQuery>();
        }

        public static void ResolveSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce Product MicroServices", Version = "v1" });
            });
        }
    }
}
