using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EcommerceMicroServices.Api.Customer.Test.Controller
{
    public class HttpClientHandlerBase
    {
        protected readonly HttpClient HttpTestClient;

        protected HttpClientHandlerBase()
        {
            var factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        //--do this if using a concrete Db-----
                        /*services.RemoveAll(typeof(DbContext));
                        services.AddDbContext<DbContext>(options =>
                        {
                            options.UseInMemoryDatabase("IntegrationTestDb");
                        });
                        */
                    });
                });
            HttpTestClient = factory.CreateClient();
        }
    }
}
 