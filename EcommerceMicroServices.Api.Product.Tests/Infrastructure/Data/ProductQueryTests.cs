using System;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceMicroServices.Api.product.Core.Interfaces;
using EcommerceMicroServices.Api.product.Infrastructure.Data;
using EcommerceMicroServices.Api.product.Infrastructure.Database;
using EcommerceMicroServices.Api.Product.Tests.Infrastructure.Database;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace EcommerceMicroServices.Api.Product.Tests.Infrastructure.Data
{
    public class ProductQueryTests
    {
        ProductsDbContext dbContextMock =ProductDbContextBuilder.InitContextWithInMemoryDbSupport();
        Mock<ILogger<ProductQuery>>loggerMock = new Mock<ILogger<ProductQuery>>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        Mock<IProductCommand> commandMock = new Mock<IProductCommand>();

        ProductQuery _sut;
        public ProductQueryTests()
        {
            _sut = new ProductQuery(dbContextMock, loggerMock.Object, mapperMock.Object, commandMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_Should_Fail_Gracefully_On_Exception()
        {
            //Arrange
            _sut = new ProductQuery(ProductDbContextBuilder.InitEmptyContext(), loggerMock.Object, mapperMock.Object, commandMock.Object);

            //Act
            var result = await _sut.GetAllAsync();
            //Assert
            result.IsSuccess.ShouldBeFalse();
            //loggerMock.Verify(x => x.LogInformation("An error was thrown"),Times.Once);
        }

        [Fact]
        public async Task GetSingleByIdAsync_Should_Fail_Gracefully_On_Exception()
        {
            //Arrange
            _sut = new ProductQuery(ProductDbContextBuilder.InitEmptyContext(), loggerMock.Object, mapperMock.Object, commandMock.Object);

            //Act
            var result = await _sut.GetSingleByIdAsync(1);
            //Assert
            result.IsSuccess.ShouldBeFalse();
            //loggerMock.Verify(x => x.LogInformation("An error was thrown"),Times.Once);
        }
    }
}
