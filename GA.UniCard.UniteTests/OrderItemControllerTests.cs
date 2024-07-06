using GA.UniCard.Api.Controllers;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace GA.UniCard.UniteTests
{
    /// <summary>
    /// Unite test class for  test order item functionalities
    /// </summary>
    public class OrderItemControllerTests
    {
        private readonly Mock<IOrderItemServices> mockOrderItemService;
        private readonly Mock<ILogger<OrderItemController>> mockLogger;
        private readonly OrderItemController controller;

        /// <summary>
        /// Order item Controller Test Constructor for inicialize private fields using moq
        /// </summary>
        public OrderItemControllerTests()
        {
            mockOrderItemService = new Mock<IOrderItemServices>();
            mockLogger = new Mock<ILogger<OrderItemController>>();
            controller = new OrderItemController(mockOrderItemService.Object, mockLogger.Object);
        }

        /// <summary>
        /// Test for inserting an invalid order item, expecting a BadRequest response.
        /// </summary>
        [Fact]
        public async Task Insert_InvalidOrderItem_ReturnsBadRequest()
        {
            OrderItemDto orderDto = new OrderItemDto(); // Invalid OrderitemDto
            var result = await controller.Insert(orderDto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for updating an invalid order item, expecting a BadRequest response.
        /// </summary>
        [Fact]
        public async Task Update_InvalidOrderItem_ReturnsBadRequest()
        {
            int orderitemId = 1;
            OrderItemDto orderItemDto = new OrderItemDto(); // Invalid OrderDto
            var result = await controller.Update(orderitemId, orderItemDto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for retrieving a non-existing order item by ID, expecting a NotFound response.
        /// </summary>
        [Fact]
        public async Task GetById_NonExistingOrderItemId_ReturnsNotFound()
        {
            long orderItemId = 1345; // Non-existing orderItemId 
            mockOrderItemService.Setup(service => service.GetByIdAsync(orderItemId)).ReturnsAsync((OrderItemDto)null);
            var result = await controller.GetById(orderItemId);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for deleting a non-existing order item by ID, expecting a NotFound response.
        /// </summary>
        [Fact]
        public async Task Delete_NonExistingOrderItemId_ReturnsNotFound()
        {
            long orderId = 1345; // Non-existing orderId
            mockOrderItemService.Setup(service => service.DeleteAsync(orderId)).ReturnsAsync(false);
            var result = await controller.Delete(orderId);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for inserting a valid Order Item, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Insert_ValidOrderItem_ReturnsOk()
        {
            var orderitemDto = new OrderItemDto {OrderId=1,Price=45,ProductId=2,Quantity=3};
            mockOrderItemService.Setup(service => service.AddAsync(It.IsAny<OrderItemDto>())).ReturnsAsync(true);
            var result = await controller.Insert(orderitemDto);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        /// <summary>
        /// Test for deleting an existing order item by ID, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Delete_ExistingOrderItemId_ReturnsOk()
        {
            long orderId = 1;
            mockOrderItemService.Setup(service => service.DeleteAsync(orderId)).ReturnsAsync(true);
            var result = await controller.Delete(orderId);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        /// <summary>
        /// Test for retrieving all order items when order items exist, expecting an OK response with orders.
        /// </summary>
        [Fact]
        public async Task GetAll_OrderItemsExist_ReturnsOkWithOrderItems()
        {
            var orders = new List<OrderItemDto> {
                new OrderItemDto(){OrderId=3,Price=234,ProductId =2,Quantity=33},
                 new OrderItemDto(){OrderId=2,Price=344,ProductId =1,Quantity=43},
                  new OrderItemDto(){OrderId=1,Price=343,ProductId =3,Quantity=3},
                   new OrderItemDto(){OrderId=4,Price=334,ProductId =4,Quantity=7},
                    new OrderItemDto(){OrderId=5,Price=64,ProductId =5,Quantity=5},
                                            };
            mockOrderItemService.Setup(service => service.GetAllAsync()).ReturnsAsync(orders);
            var result = await controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<OrderItemDto>>(okResult.Value);
            Assert.Equal(orders.Count, model.Count());
        }

        /// <summary>
        /// Test for retrieving an existing ordeitem by ID, expecting an OK response with the orderItem.
        /// </summary>
        [Fact]
        public async Task GetById_ExistingOrderItemId_ReturnsOkWithOrderItem()
        {
            long orderItemId = 1;
            var orderItemDto = new OrderItemDto { OrderId = 1, Price = 45, ProductId = 2, Quantity = 3 };
            mockOrderItemService.Setup(service => service.GetByIdAsync(orderItemId)).ReturnsAsync(orderItemDto);
            var result = await controller.GetById(orderItemId);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<OrderItemDto>(okResult.Value);
            Assert.Equal(orderItemDto.OrderId, model.OrderId);
        }

        /// <summary>
        /// Test for updating a valid order Item, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Update_ValidOrderItem_ReturnsOk()
        {
            long orderItemId = 1;
            var orderItemDto = new OrderItemDto { OrderId=3,Price=345,ProductId=2,Quantity=34};
            mockOrderItemService.Setup(service => service.UpdateAsync(orderItemId, orderItemDto)).ReturnsAsync(true);
            var result = await controller.Update(orderItemId, orderItemDto);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }
    }
}
