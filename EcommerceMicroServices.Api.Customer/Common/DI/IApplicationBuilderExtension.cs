using System;
using Microsoft.AspNetCore.Builder;

namespace EcommerceMicroServices.Api.Customer.Common.DI
{
    public static class IApplicationBuilderExtension
    {
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseSwagger();

            appBuilder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Ecommerce V1");
                c.RoutePrefix = string.Empty;
            });

            return appBuilder;
        }

        public static IApplicationBuilder ConfigureCors(this IApplicationBuilder appBuilder)
            => appBuilder.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
    }
}
