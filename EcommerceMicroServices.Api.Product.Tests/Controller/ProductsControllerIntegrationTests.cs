using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace EcommerceMicroServices.Api.Product.Tests.Controller
{
    public class ProductsControllerIntegrationTests : HttpClientHandlerBase
    {


        [Theory]
        [InlineData("api/Products")]
        public async Task GetAll_Should_Return_Ok(string url)
        {
            //Arrange

            //Act
            var response = await HttpTestClient.GetAsync(url);
            //Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }



        [Theory]
        [InlineData("api/Products/", 1)]
        public async Task GetSingleById_Should_Return_Ok(string url, int id)
        {
            //Arrange

            //Act
            var response = await HttpTestClient.GetAsync($"{url}{id}");
            //Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("api/Products/GetSingleById/", int.MaxValue)]
        public async Task GetSingleById_Should_Return_NotFound(string url, int id)
        {
            //Arrange

            //Act
            var response = await HttpTestClient.GetAsync($"{url}{id}");
            //Assert
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.NotFound);
        }
    }
}
