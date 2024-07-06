using GA.UniCard.Api.Controllers;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace GA.UniCard.UniteTests
{
    /// <summary>
    /// Unite tests for test User Functionalities
    /// </summary>
    public class UserControllerTests
    {
        private readonly Mock<IUserService> mockUserService;
        private readonly Mock<ILogger<UserController>> mockLogger;
        private readonly UserController controller;

        /// <summary>
        /// User Controller Test Constructor for inicialize private fields using moq
        /// </summary>
        public UserControllerTests()
        {
            mockUserService = new Mock<IUserService>();
            mockLogger = new Mock<ILogger<UserController>>();
            controller = new UserController(mockUserService.Object, mockLogger.Object);
        }

        /// <summary>
        /// Test for inserting an invalid User, expecting a BadRequest response.
        /// </summary>
        [Fact]
        public async Task Register_InvalidUser_ReturnsBadRequest()
        {
            UserDto orderDto = new UserDto(); // Invalid User Dto
            var result = await controller.Insert(orderDto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for updating an invalid User, expecting a BadRequest response.
        /// </summary>
        [Fact]
        public async Task Update_InvalidUser_ReturnsBadRequest()
        {
            int UserId = 1;
            UserDto userDto = new UserDto(); // Invalid user Dto
            var result = await controller.Update(UserId, userDto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for retrieving a non-existing User by ID, expecting a NotFound response.
        /// </summary>
        [Fact]
        public async Task GetById_NonExistingUserId_ReturnsNotFound()
        {
            long UserId = 1345; // Non-existing UserId
            mockUserService.Setup(service => service.GetByIdAsync(UserId)).ReturnsAsync((UserDto)null);
            var result = await controller.GetById(UserId);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for deleting a non-existing User by ID, expecting a NotFound response.
        /// </summary>
        [Fact]
        public async Task Delete_NonExistingUserId_ReturnsNotFound()
        {
            long userId = 1345; // Non-existing UserId
            mockUserService.Setup(service => service.RemoveUser(userId)).ReturnsAsync(false);
            var result = await controller.Delete(userId);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        /// <summary>
        /// Test for inserting a valid User, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Register_ValidUser_ReturnsOk()
        {
            var userDto = new UserDto {Email="Admin@gmail.com",Password="Guga13$",UserName="Gaga2345"};
            mockUserService.Setup(service => service.Register(It.IsAny<UserDto>())).ReturnsAsync(true);
            var result = await controller.Insert(userDto);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        /// <summary>
        /// Test for deleting an existing User by ID, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Delete_ExistingUserId_ReturnsOk()
        {
            long UserId = 1;
            mockUserService.Setup(service => service.RemoveUser(UserId)).ReturnsAsync(true);
            var result = await controller.Delete(UserId);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        /// <summary>
        /// Test for retrieving all Users when Users exist, expecting an OK response with orders.
        /// </summary>
        [Fact]
        public async Task GetAll_UsersExist_ReturnsOkWithOrders()
        {
            var users = new List<UserDto> {
                new UserDto(){Email="Giorgi@gmail.com",Password="Gaga234",UserName="There1234"},
                new UserDto(){Email="Pnguin@gmail.com",Password="Penguin234",UserName="Penguin1234"},
                                            };
            mockUserService.Setup(service => service.GetAllAsync()).ReturnsAsync(users);
            var result = await controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserDto>>(okResult.Value);
            Assert.Equal(users.Count, model.Count());
        }

        /// <summary>
        /// Test for retrieving an existing User by ID, expecting an OK response with the User.
        /// </summary>
        [Fact]
        public async Task GetById_ExistingUserId_ReturnsOkWithUser()
        {
            long UserId = 1;
            var UserDto = new UserDto { Email="Gaga123@gmail.com",Password="Ramdeni123#",UserName="Cxvari123"};
            mockUserService.Setup(service => service.GetByIdAsync(UserId)).ReturnsAsync(UserDto);
            var result = await controller.GetById(UserId);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(UserDto.UserName, model.UserName);
        }

        /// <summary>
        /// Test for updating a valid User, expecting an OK response.
        /// </summary>
        [Fact]
        public async Task Update_ValidUser_ReturnsOk()
        {
            long UserId = 1;
            var UserDto = new UserDto { Email = "Gaga123@gmail.com", Password = "Ramdeni123#", UserName = "Cxvari123" };
            mockUserService.Setup(service => service.UpdateAsync(UserId, UserDto)).ReturnsAsync(true);
            var result = await controller.Update(UserId, UserDto);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }
    }
}
