using System;
using EcommerceMicroServices.Api.Customer.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using EcommerceMicroServices.Api.Customer.Core.Interfaces;
using EcommerceMicroServices.Api.Customer.Infrastructure.Data;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace EcommerceMicroServices.Api.Customer.Common.DI
{
    public static class IServiceCollectionExtension
    {
        public static void ConfigureInMemoryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<CustomersDbContext>(options =>
            {
                options.UseInMemoryDatabase("CustomerDb");
            });
        }

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICustomerCommand, CustomerCommand>();
            services.AddScoped<ICustomerQuery, CustomerQuery>();
        }

        public static void ResolveSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce Customer MicroServices", Version = "v1" });
            });
        }
    }
}
