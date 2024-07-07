using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.Models.ResponseModels;
using GA.UniCard.Application.StaticFiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GA.UniCard.Api.Controllers
{
    /// <summary>
    /// API controller for managing users.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for CRUD operations on users.
    /// </remarks>
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger<UserController> logger;

        /// <summary>
        /// Constructor for UserController.
        /// </summary>
        /// <param name="userService">User service dependency.</param>
        /// <param name="logger">Logger dependency.</param>
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <returns>True if registration is successful, otherwise false.</returns>
        /// <remarks>
        /// Registers a new user in the system. Returns success or failure.
        /// </remarks>
        [MapToApiVersion("2.0")]
        [HttpPost]
        [SwaggerOperation(Summary = "Register a new user V2.0", Description = "Registers a new user in the system. **CUSTOMER,ADMIN,OPERATOR**")]
        [SwaggerResponse(200, SuccessKeys.InsertSuccess, typeof(bool))]
        [SwaggerResponse(400, ErrorKeys.BadRequest, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [Authorize(Roles = "CUSTOMER,ADMIN,OPERATOR")]
        public async Task<ActionResult<bool>> Insert([FromBody, SwaggerParameter(InfoKeys.UserInfo, Required = true)] UserDto user)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await userService.Register(user);
            if (res)
            {
                logger.LogInformation($"{SuccessKeys.Success} {user.Email}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        /// <summary>
        /// Delete a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        /// <remarks>
        /// Deletes an existing user from the system by their ID. Returns success or failure.
        /// </remarks>
        [HttpDelete]
        [Route("{userId:long}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Delete a user V2.0", Description = "Deletes an existing user from the system by their ID. **ADMIN,OPERATOR**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(bool))]
        [SwaggerResponse(400, ErrorKeys.BadRequest, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [Authorize(Roles = "ADMIN,OPERATOR")]
        public async Task<ActionResult<bool>> Delete([FromRoute, SwaggerParameter(InfoKeys.UserId, Required = true)] long userId)
        {
            var res = await userService.RemoveUser(userId);
            if (res)
            {
                logger.LogInformation($"{SuccessKeys.Delete} {userId}");
                return Ok(res);
            }
            else
            {
                return NotFound(ErrorKeys.UnsuccesfullInsert);
            }
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        /// <remarks>
        /// Retrieves all users from the system. Returns a list of users.
        /// </remarks>
        [HttpGet]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Get all users V2.0", Description = "Retrieves all users from the system. **Allow Anymous**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(IEnumerable<UserDto>))]
        [SwaggerResponse(404, ErrorKeys.NotFound, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var res = await userService.GetAllAsync();
            if (res.Any())
            {
                logger.LogInformation($"{SuccessKeys.Success}");
                return Ok(res);
            }
            else
            {
                return NotFound(ErrorKeys.NotFound);
            }
        }

        /// <summary>
        /// Get a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID.</returns>
        /// <remarks>
        /// Retrieves a specific user from the system by their ID. Returns the user if found, otherwise returns NotFound.
        /// </remarks>
        [HttpGet]
        [Route("{userId:long}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Get a user by ID V2.0", Description = "Retrieves a specific user from the system by their ID. ** Allow Anymous**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(UserDto))]
        [SwaggerResponse(404, ErrorKeys.NotFound, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        public async Task<ActionResult<UserDto>> GetById([FromRoute, SwaggerParameter(InfoKeys.UserId, Required = true)] long userId)
        {
            var res = await userService.GetByIdAsync(userId);
            if (res is null)
            {
                return NotFound(ErrorKeys.NotFound);
            }
            else
            {
                return Ok(res);
            }
        }

        /// <summary>
        /// Update a user.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="user">The updated user data.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        /// <remarks>
        /// Updates an existing user in the system with new data. Returns success or failure.
        /// </remarks>
        [HttpPut]
        [Route("{userId:long}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Update a user V2.0", Description = "Updates an existing user in the system with new data. **CUSTOMER,ADMIN,OPERATOR**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(bool))]
        [SwaggerResponse(400, ErrorKeys.BadRequest, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [Authorize(Roles = "CUSTOMER,ADMIN,OPERATOR")]
        public async Task<ActionResult<bool>> Update([FromRoute, SwaggerParameter(InfoKeys.UserId, Required = true)] long userId, [FromBody, SwaggerParameter(InfoKeys.orderInfo, Required = true)] UserDto user)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await userService.UpdateAsync(userId, user);
            if (res)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsucessfullUpdate);
            }
        }
    }
}
