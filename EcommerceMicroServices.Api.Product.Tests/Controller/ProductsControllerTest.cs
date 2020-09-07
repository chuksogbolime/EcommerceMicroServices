using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceMicroServices.Api.product.Controllers;
using EcommerceMicroServices.Api.product.Core.Interfaces;
using EcommerceMicroServices.Api.product.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Xunit;

namespace EcommerceMicroServices.Api.Product.Tests.Controller
{
    public class ProductsControllerTest
    {
        private ProductsController _sut;
        private Mock<IProductQuery> _productQueryMock = new Mock<IProductQuery>();
        public ProductsControllerTest()
        {
            _sut = new ProductsController(_productQueryMock.Object);
        }

        [Fact]
        public async Task GetAll_Should_Return_List_Of_Pruducts_If_Exist()
        {
            //Arrange
            List<ProductModel> products = new List<ProductModel>
            {
                new ProductModel
                {
                    Id=1,
                    Inventory=2,
                    Name="Product 1",
                    Price=20
                },
                 new ProductModel
                {
                    Id=2,
                    Inventory=20,
                    Name="Product 2",
                    Price=400
                }
            };
            _productQueryMock.Setup(o => o.GetAllAsync()).ReturnsAsync(()=>(true,products,null));

            //Act
            var result = await _sut.GetAll();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            okResult.Value.ShouldBe(products);
        }

        [Fact]
        public async Task GetAll_Should_Return_NotFound_If_No_Product_Exist()
        {
            //Arrange
          
            _productQueryMock.Setup(o => o.GetAllAsync()).ReturnsAsync(() => (false, null, null));

            //Act
            var result = await _sut.GetAll();

            //Assert
            
            result.ShouldBeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public async Task GetGetSingleById_Should_Return_Product_If_Exist()
        {
            //Arrange
            int productId = 1;
            ProductModel product = new ProductModel
            {
                Id = productId,
                Inventory = 2,
                Name = "Product 1",
                Price = 20
            };

            _productQueryMock.Setup(o => o.GetSingleByIdAsync(productId)).ReturnsAsync(() => (true, product, null));

            //Act
            var result = await _sut.GetGetSingleById(productId);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            okResult.Value.ShouldBe(product);
        }

        [Fact]
        public async Task GetGetSingleById_Should_Return_NotFound_If_Product_Does_Not_Exist()
        {
            //Arrange

            _productQueryMock.Setup(o => o.GetSingleByIdAsync(It.IsAny<int>())).ReturnsAsync(() => (false, null, null));

            //Act
            var result = await _sut.GetGetSingleById(1);

            //Assert
           
            result.ShouldBeOfType(typeof(NotFoundResult));
        }
    }
}
