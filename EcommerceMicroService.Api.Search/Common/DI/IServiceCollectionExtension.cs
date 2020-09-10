using System;
using System.Net.Http;
using EcommerceMicroService.Api.Search.Core.Common;
using EcommerceMicroService.Api.Search.Core.Interfaces;
using EcommerceMicroService.Api.Search.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Polly;

namespace EcommerceMicroService.Api.Search.Common.DI
{
    public static class IServiceCollectionExtension
    {
        

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IProductsService, ProductsServices>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            
        }
        public static void ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            services.AddHttpClient(HttpClientName.ORDERS, config =>
            {
                config.BaseAddress = new Uri(configuration["Services:Order"]);
                
                
            })
                .ConfigurePrimaryHttpMessageHandler(() => httpClientHandler)
                .AddTransientHttpErrorPolicy(r => r.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(300)));

            services.AddHttpClient(HttpClientName.PRODUCTS, config =>
            {
                config.BaseAddress = new Uri(configuration["Services:Product"]);


            })
                .ConfigurePrimaryHttpMessageHandler(() => httpClientHandler)
                .AddTransientHttpErrorPolicy(r => r.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(300)));
            services.AddHttpClient(HttpClientName.CHECKOUTS, config =>
            {
                config.BaseAddress = new Uri(configuration["Services:Checkout"]);


            })
                .ConfigurePrimaryHttpMessageHandler(() => httpClientHandler)
                .AddTransientHttpErrorPolicy(r => r.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(300)));

            services.AddHttpClient(HttpClientName.CUSTOMER, config =>
            {
                config.BaseAddress = new Uri(configuration["Services:Customer"]);


            })
                .ConfigurePrimaryHttpMessageHandler(() => httpClientHandler)
                .AddTransientHttpErrorPolicy(r => r.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(300)));
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
