using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace EcommerceMicroServices.Api.Customer.Test.Controller
{
    public class CustomerControllerIntegrationTests : HttpClientHandlerBase
    {


        [Theory]
        [InlineData("api/Customers")]
        public async Task GetAll_Should_Return_Ok(string url)
        {
            //Arrange

            //Act
            var response = await HttpTestClient.GetAsync(url);
            //Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }

       

        [Theory]
        [InlineData("api/Customers/GetGetSingleById/", 1)]
        public async Task GetGetSingleById_Should_Return_Ok(string url, int id)
        {
            //Arrange

            //Act
            var response = await HttpTestClient.GetAsync($"{url}{id}");
            //Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("api/Customers/GetGetSingleById/", int.MaxValue)]
        public async Task GetGetSingleById_Should_Return_NotFound(string url, int id)
        {
            //Arrange

            //Act
            var response = await HttpTestClient.GetAsync($"{url}{id}");
            //Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.NotFound);
        }

    }
}
