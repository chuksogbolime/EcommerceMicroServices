using Microsoft.AspNetCore.Builder;

namespace EcommerceMicroService.Api.Search.Common.DI
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

        //public static IApplicationBuilder AddGlobalExceptionHandler(this IApplicationBuilder app)
          //  => app.UseMiddleware<GlobalExceptionMiddleware>();
    }

    
}
