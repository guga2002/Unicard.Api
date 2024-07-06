using GA.UniCard.Api.Controllers;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;

namespace GA.UniCard.UniteTests
{
    /// <summary>
    /// ProductController tests  for  test  endpoints
    /// </summary>
    public class ProductControllerTests
    {
        private readonly Mock<IproductServices> mockProductService;
        private readonly Mock<ILogger<ProductController>> mockLogger;
        private readonly ProductController controller;
        private readonly Mock<IMemoryCache> cache;

        /// <summary>
        /// Product Controller Test Constructor for inicialize private fields using moq
        /// </summary>
        public ProductControllerTests()
        {
            mockProductService = new Mock<IproductServices>();
            mockLogger = new Mock<ILogger<ProductController>>();
            cache = new Mock<IMemoryCache>();
            controller = new ProductController(mockProductService.Object, mockLogger.Object,cache.Object);
        }

        /// <summary>
        /// Test for inserting an invalid Product, expecting a BadRequest response.
        /// </summary>
        [Fact]
        public async Task Insert_InvalidProduct_ReturnsBadRequest()
        {
            ProductDto productDto = new ProductDto(); // Invalid ProductDto
            var result = await controller.Insert(productDto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for updating an invalid Product, expecting a BadRequest response.
        /// </summary>
        [Fact]
        public async Task Update_InvalidProduct_ReturnsBadRequest()
        {
            int productId = 1;
            ProductDto productDto = new ProductDto(); // Invalid productDto
            var result = await controller.Update(productId, productDto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for retrieving a non-existing product by ID, expecting a NotFound response.
        /// </summary>
        [Fact]
        public async Task GetById_NonExistingProductId_ReturnsNotFound()
        {
            long productId = 1345; // Non-existing ProductId
            mockProductService.Setup(service => service.GetByIdAsync(productId)).ReturnsAsync((ProductDto)null);
            var result = await controller.GetById(productId);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for deleting a non-existing Product by ID, expecting a NotFound response.
        /// </summary>
        [Fact]
        public async Task Delete_NonExistingproductId_ReturnsNotFound()
        {
            long ProductId = 1345; // Non-existing productId
            mockProductService.Setup(service => service.DeleteAsync(ProductId)).ReturnsAsync(false);
            var result = await controller.Delete(ProductId);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for inserting a valid product, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Insert_ValidProduct_ReturnsOk()
        {
            var ProductDto = new ProductDto() { Description = "Good product", Price = 45, ProductName = "Bread" };
            mockProductService.Setup(service => service.AddAsync(It.IsAny<ProductDto>())).ReturnsAsync(true);
            var result = await controller.Insert(ProductDto);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        /// <summary>
        /// Test for deleting an existing Product by ID, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Delete_ExistingProductId_ReturnsOk()
        {
            long productId = 1;
            mockProductService.Setup(service => service.DeleteAsync(productId)).ReturnsAsync(true);
            var result = await controller.Delete(productId);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        /// <summary>
        /// Test for retrieving all products when products exist, expecting an OK response with orders.
        /// </summary>
        [Fact]
        public async Task GetAll_ProductsExist_ReturnsOkWithProducts()
        {
            var Products = new List<ProductDto>
            {
                new ProductDto(){Description="Bad product",Price=34,ProductName="Cat dees"},
                 new ProductDto(){Description="Life is good",Price=3445,ProductName="LG TV"},
                   new ProductDto(){Description="vegetale",Price=344,ProductName="wrap"},
                 new ProductDto(){Description="Lets  build together",Price=35,ProductName="Samsung Phone"},
                                            };
            mockProductService.Setup(service => service.GetAllAsync()).ReturnsAsync(Products);
            var result = await controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);
            Assert.Equal(Products.Count, model.Count());
        }

        /// <summary>
        /// Test for retrieving an existing product by ID, expecting an OK response with the order.
        /// </summary>
        [Fact]
        public async Task GetById_ExistingProductId_ReturnsOkWithOrder()
        {
            long productId = 1;
            var productDto = new ProductDto { Description="Good Now",Price=45,ProductName="Milk" };
            mockProductService.Setup(service => service.GetByIdAsync(productId)).ReturnsAsync(productDto);
            var result = await controller.GetById(productId);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<ProductDto>(okResult.Value);
            Assert.Equal(productDto.ProductName, model.ProductName);
        }

        /// <summary>
        /// Test for updating a valid Product, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Update_ValidProduct_ReturnsOk()
        {
            long ProductId = 1;
            var productDto = new ProductDto { Description = "Good Now", Price = 45, ProductName = "Milk" };
            mockProductService.Setup(service => service.UpdateAsync(ProductId, productDto)).ReturnsAsync(true);
            var result = await controller.Update(ProductId, productDto);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }
    }
}
