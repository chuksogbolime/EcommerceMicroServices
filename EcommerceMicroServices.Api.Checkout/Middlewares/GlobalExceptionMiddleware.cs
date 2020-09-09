using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EcommerceMicroServices.Api.Checkout.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
            
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            
            try
            {
                await _next(httpContext);
            }
            catch (FluentValidation.ValidationException ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError(ex.ToString());
                await httpContext.Response.WriteAsync(ex.Message, Encoding.UTF8);
            }
            catch (Exception ex)
            {

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError(ex.ToString());
                await httpContext.Response.WriteAsync(ex.Message, Encoding.UTF8);
            }
            

        }
    }
}
