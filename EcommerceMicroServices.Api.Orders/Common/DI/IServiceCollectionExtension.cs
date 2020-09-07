using System;
using EcommerceMicroServices.Api.Orders.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using EcommerceMicroServices.Api.Orders.Core.Interfaces;
using EcommerceMicroServices.Api.Orders.Infrastructure.Data;
using AutoMapper;
using Microsoft.OpenApi.Models;
using EcommerceMicroServices.Api.Orders.Core.UseCase;

namespace EcommerceMicroServices.Api.Customer.Common.DI
{
    public static class IServiceCollectionExtension
    {
        public static void ConfigureInMemoryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseInMemoryDatabase("OrdersDb");
            });
        }

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IOrderCommand, OrderCommand>();
            services.AddScoped<IOrderQuery, OrderQuery>();
            services.AddScoped<IOrderItemCommand, OrderItemCommand>();
            services.AddScoped<IOrderItemQuery, OrderItemQuery>();
            services.AddScoped<IOrderProvider, OrderProvider>();
        }

        public static void ResolveSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce Orders MicroServices", Version = "v1" });
            });
        }
    }
}
