using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.Customer.Controllers;
using EcommerceMicroServices.Api.Customer.Core.Interfaces;
using EcommerceMicroServices.Api.Customer.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using Xunit;
using Moq;

namespace EcommerceMicroServices.Api.Customer.Test.Controller
{
    public class CustomerControllerTests
    {
        private CustomerController _sut;
        private Mock<ICustomerQuery> _customerQueryMock = new Mock<ICustomerQuery>();
        public CustomerControllerTests()
        {
            _sut = new CustomerController(_customerQueryMock.Object);
        }

        [Fact]
        public async Task GetAll_Should_Return_List_Of_Customers_If_Exist()
        {
            //Arrange
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    Id=1,
                    Address="Address 1",
                    Name="Customer 1"
                    
                },
                 new CustomerModel
                {
                    Id=2,
                    Address="Address 2",
                    Name="Customer 2"

                }
            };
            _customerQueryMock.Setup(o => o.GetAllAsync()).ReturnsAsync(() => (true, customers, null));

            //Act
            var result = await _sut.GetAll();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            okResult.Value.ShouldBe(customers);
        }

        [Fact]
        public async Task GetAll_Should_Return_NotFound_If_No_Product_Exist()
        {
            //Arrange

            _customerQueryMock.Setup(o => o.GetAllAsync()).ReturnsAsync(() => (false, null, null));

            //Act
            var result = await _sut.GetAll();

            //Assert

            result.ShouldBeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public async Task GetGetSingleById_Should_Return_Product_If_Exist()
        {
            //Arrange
            int customerId = 1;
            CustomerModel customer = new CustomerModel
            {
                Id = customerId,
                Address = "Address 1",
                Name = "Customer 1"

            };

            _customerQueryMock.Setup(o => o.GetSingleByIdAsync(customerId)).ReturnsAsync(() => (true, customer, null));

            //Act
            var result = await _sut.GetSingleById(customerId);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            okResult.Value.ShouldBe(customer);
        }

        [Fact]
        public async Task GetGetSingleById_Should_Return_NotFound_If_Product_Does_Not_Exist()
        {
            //Arrange

            _customerQueryMock.Setup(o => o.GetSingleByIdAsync(It.IsAny<int>())).ReturnsAsync(() => (false, null, null));

            //Act
            var result = await _sut.GetSingleById(1);

            //Assert

            result.ShouldBeOfType(typeof(NotFoundResult));
        }
    }
}
