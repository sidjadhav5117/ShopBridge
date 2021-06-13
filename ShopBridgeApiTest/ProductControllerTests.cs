using Moq;
using ShopBridgeApi.Controllers;
using ShopBridgeApi.Service;
using ShopBridgeModels.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridgeApiTest
{
    public class ProductControllerTests : IDisposable
    {
        private readonly ProductController productController;
        private readonly Mock<IProductService> mockProductService;

        public ProductControllerTests()
        {
            this.mockProductService = new Mock<IProductService>();
            this.productController = new ProductController(this.mockProductService.Object);
        }

        [Fact]
        public void Task_GetProducts_Return_OkResult()
        {
            //Act
            var data = productController.Get();

            this.mockProductService.Verify(p => p.GetProducts());

            //Assert
            Assert.IsType<Task<IEnumerable<Product>>>(data);
        }

        [Fact]
        public void Task_GetProduct_Return_OkResult()
        {
            //Act
            var data = this.productController.Get(1);

            this.mockProductService.Verify(p => p.GetProduct(1));

            //Assert
            Assert.IsType<Task<Product>>(data);
        }

        [Fact]
        public void Task_AddPerson_Return_OkResult()
        {
            //Arrange
            Product product = new Product
            {
                ProductCode = "P101",
                ProductName = "TestProduct",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Description = "This is the test product.",
                PurchaseCost = 100,
                SellingCost = 135,
            };
            
            this.mockProductService.Setup(p => p.AddProduct(product)).ReturnsAsync(product);

            //Act
            var response = this.productController.Post(product);

            this.mockProductService.Verify(p => p.AddProduct(product));

            //Assert
            Assert.IsType<Task<Product>>(response);
        }

        [Fact]

        public void Task_DeleteProduct_Return_OkResult()
        {
            //Act
            var response = this.productController.Delete(1);

            this.mockProductService.Verify(p => p.DeleteProduct(1));

            //Assert
            Assert.IsType<Task<bool>>(response);
        }

        [Fact]
        public void Task_UpdateProduct_Return_OkResult()
        {
            //Arrange
            Product product = new Product
            {
                Id = 1,
                ProductCode = "P101",
                ProductName = "TestProduct",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Description = "This is the test product.",
                PurchaseCost = 100,
                SellingCost = 135,
            };

            this.mockProductService.Setup(p => p.UpdateProduct(product)).ReturnsAsync(product);

            //Act
            var response = this.productController.Put(product);

            this.mockProductService.Verify(p => p.UpdateProduct(product));

            //Assert
            Assert.IsType<Task<Product>>(response);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
