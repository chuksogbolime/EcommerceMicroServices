using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.OpenApi.Models;
using EcommerceMicroServices.Api.Checkout.Data;
using EcommerceMicroServices.Api.Checkout.Data.Interfaces;
using EcommerceMicroServices.Api.Checkout.Data.InterfaceImpl;
using MediatR;

namespace EcommerceMicroServices.Api.Checkout.Common.DI
{
    public static class IServiceCollectionExtension
    {
        public static void ConfigureInMemoryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<CheckoutDbContext>(options =>
            {
                options.UseInMemoryDatabase("CheckoutDb");
            });
        }

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICheckoutCommand, CheckoutCommand>();
            services.AddScoped<ICheckoutQuery, CheckoutQuery>();
        }
        public static void AddMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
        }

        public static void ResolveSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce Checkout MicroServices", Version = "v1" });
            });
        }
    }
}
