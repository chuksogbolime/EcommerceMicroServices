using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceMicroServices.Api.Orders.Infrastructure.Data;
using EcommerceMicroServices.Api.Orders.Infrastructure.Database;
using Microsoft.Extensions.Logging;
using Moq;
using NetCoreLoggerAdapter;
using Shouldly;
using Xunit;

namespace EcommerceMicroServices.Api.Orders.Tests.Unit.Data
{
    public class OrderQueryTest
    {
        OrdersDbContext dbContextMock = DbContextBuilder.InitContextWithInMemoryDbSupport();
        Mock<ILoggerServiceAdapter<OrderQuery>> loggerMock = new Mock<ILoggerServiceAdapter<OrderQuery>>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();

        MapperConfiguration mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new Common.ObjectMapProfiles.OrdersMapProfile());
        });

        OrderQuery _sut;
        

        [Fact]
        public async Task GetAllAsync_Should_Fail_Gracefully_On_Exception()
        {
            //Arrange
            _sut = new OrderQuery(DbContextBuilder.InitEmptyContext(), loggerMock.Object, mapperMock.Object);

            //Act
            var result = await _sut.GetAllAsync();
            //Assert
            result.IsSuccess.ShouldBeFalse();
            loggerMock.Verify(x => x.LogError(It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetSingleByIdAsync_Should_Fail_Gracefully_On_Exception()
        {
            //Arrange
            _sut = new OrderQuery(DbContextBuilder.InitEmptyContext(), loggerMock.Object, mapper.CreateMapper());

            //Act
            var result = await _sut.GetSingleByIdAsync(1);
            //Assert
            result.IsSuccess.ShouldBeFalse();
            loggerMock.Verify(x => x.LogError(It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Valid_List()
        {
            //Arrange
            dbContextMock = DbContextBuilder.InitContextWithInMemoryDbSupport();

            _sut = new OrderQuery(dbContextMock, loggerMock.Object, mapper.CreateMapper());
            //Act
            var result = await _sut.GetAllAsync();
            //Assert
            result.IsSuccess.ShouldBeTrue();
            result.Result.ShouldNotBeNull();
            result.Result.Any().ShouldBeTrue();
            result.Result.FirstOrDefault().OrderId.ShouldBe(1);
            result.ErrorMessage.ShouldBeNull();
        }
    }
}
