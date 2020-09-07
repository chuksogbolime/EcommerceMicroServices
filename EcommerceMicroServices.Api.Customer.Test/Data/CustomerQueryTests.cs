using System;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceMicroServices.Api.Customer.Core.Interfaces;
using EcommerceMicroServices.Api.Customer.Infrastructure.Data;
using EcommerceMicroServices.Api.Customer.Infrastructure.Database;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using Shouldly;

namespace EcommerceMicroServices.Api.Customer.Test.Data
{
    public class CustomerQueryTests
    {
        CustomersDbContext dbContextMock = DbContextBuilder.InitContextWithInMemoryDbSupport();
        Mock<ILogger<CustomerQuery>> loggerMock = new Mock<ILogger<CustomerQuery>>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        Mock<ICustomerCommand> commandMock = new Mock<ICustomerCommand>();

        CustomerQuery _sut;
        public CustomerQueryTests()
        {
            _sut = new CustomerQuery(dbContextMock, commandMock.Object, loggerMock.Object, mapperMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_Should_Fail_Gracefully_On_Exception()
        {
            //Arrange
            _sut = new CustomerQuery(DbContextBuilder.InitEmptyContext(), commandMock.Object, loggerMock.Object, mapperMock.Object);

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
            _sut = new CustomerQuery(DbContextBuilder.InitEmptyContext(), commandMock.Object, loggerMock.Object, mapperMock.Object);

            //Act
            var result = await _sut.GetSingleByIdAsync(1);
            //Assert
            result.IsSuccess.ShouldBeFalse();
            //loggerMock.Verify(x => x.LogInformation("An error was thrown"),Times.Once);
        }
    }
}
