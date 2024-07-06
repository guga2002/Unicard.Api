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
    /// Unit tests for the OrderController class.
    /// </summary>
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> mockOrderService;
        private readonly Mock<ILogger<OrderController>> mockLogger;
        private readonly OrderController controller;
        private readonly Mock<IMemoryCache> cech;

        /// <summary>
        /// Order Controller Test Constructor for inicialize private fields using moq
        /// </summary>
        public OrderControllerTests()
        {
            mockOrderService = new Mock<IOrderService>();
            mockLogger = new Mock<ILogger<OrderController>>();
            cech=new Mock<IMemoryCache>();
            controller = new OrderController(mockOrderService.Object, mockLogger.Object, cech.Object);
        }

        /// <summary>
        /// Test for inserting an invalid order, expecting a BadRequest response.
        /// </summary>
        [Fact]
        public async Task Insert_InvalidOrder_ReturnsBadRequest()
        {
            OrderDto orderDto = new OrderDto(); // Invalid OrderDto
            var result = await controller.Insert(orderDto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for updating an invalid order, expecting a BadRequest response.
        /// </summary>
        [Fact]
        public async Task Update_InvalidOrder_ReturnsBadRequest()
        {
            int orderId = 1;
            OrderDto orderDto = new OrderDto(); // Invalid OrderDto
            var result = await controller.Update(orderId, orderDto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for retrieving a non-existing order by ID, expecting a NotFound response.
        /// </summary>
        [Fact]
        public async Task GetById_NonExistingOrderId_ReturnsNotFound()
        {
            long orderId = 1345; // Non-existing orderId
            mockOrderService.Setup(service => service.GetByIdAsync(orderId)).ReturnsAsync((OrderDto)null);
            var result = await controller.GetById(orderId);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for deleting a non-existing order by ID, expecting a NotFound response.
        /// </summary>
        [Fact]
        public async Task Delete_NonExistingOrderId_ReturnsNotFound()
        {
            long orderId = 1345; // Non-existing orderId
            mockOrderService.Setup(service => service.DeleteAsync(orderId)).ReturnsAsync(false); // Simulate non-existing order
            var result = await controller.Delete(orderId);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for inserting a valid order, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Insert_ValidOrder_ReturnsOk()
        {
            var orderDto = new OrderDto { OrderDate = DateTime.Now, TotalAmount = 50, UserId = 1 };
            mockOrderService.Setup(service => service.AddAsync(It.IsAny<OrderDto>())).ReturnsAsync(true);
            var result = await controller.Insert(orderDto);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        /// <summary>
        /// Test for deleting an existing order by ID, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Delete_ExistingOrderId_ReturnsOk()
        {
            long orderId = 1;
            mockOrderService.Setup(service => service.DeleteAsync(orderId)).ReturnsAsync(true);
            var result = await controller.Delete(orderId);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        /// <summary>
        /// Test for retrieving all orders when orders exist, expecting an OK response with orders.
        /// </summary>
        [Fact]
        public async Task GetAll_OrdersExist_ReturnsOkWithOrders()
        {
            var orders = new List<OrderDto> { new OrderDto() { OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 34, UserId = 2 },
                                              new OrderDto() { OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 24, UserId = 1 },
                                              new OrderDto() { OrderDate = DateTime.Now.AddDays(-3), TotalAmount = 344, UserId = 1 },
                                              new OrderDto() { OrderDate = DateTime.Now.AddDays(-4), TotalAmount = 67, UserId = 3 },
                                            };
            mockOrderService.Setup(service => service.GetAllAsync()).ReturnsAsync(orders);
            var result = await controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<OrderDto>>(okResult.Value);
            Assert.Equal(orders.Count, model.Count());
        }

        /// <summary>
        /// Test for retrieving an existing order by ID, expecting an OK response with the order.
        /// </summary>
        [Fact]
        public async Task GetById_ExistingOrderId_ReturnsOkWithOrder()
        {
            long orderId = 1;
            var orderDto = new OrderDto { OrderDate = DateTime.Now.AddDays(-3), TotalAmount = 345, UserId = 1 };
            mockOrderService.Setup(service => service.GetByIdAsync(orderId)).ReturnsAsync(orderDto);
            var result = await controller.GetById(orderId);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<OrderDto>(okResult.Value);
            Assert.Equal(orderDto.UserId, model.UserId);
        }

        /// <summary>
        /// Test for updating a valid order, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Update_ValidOrder_ReturnsOk()
        {
            long orderId = 1;
            var orderDto = new OrderDto { OrderDate = DateTime.Now.AddDays(-3), TotalAmount = 345, UserId = 1 };
            mockOrderService.Setup(service => service.UpdateAsync(orderId, orderDto)).ReturnsAsync(true);
            var result = await controller.Update(orderId, orderDto);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }
    }
}
