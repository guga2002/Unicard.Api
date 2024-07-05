using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.StatickFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    public class UserController : ControllerBase
    {
        private readonly IUserService ser;
        private readonly ILogger<UserController> Log;

        /// <summary>
        /// Constructor for UserController.
        /// </summary>
        /// <param name="ser">User service dependency.</param>
        /// <param name="logger">Logger dependency.</param>
        public UserController(IUserService ser, ILogger<UserController> logger)
        {
            this.ser = ser;
            this.Log = logger;
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
        public async Task<ActionResult<bool>> Insert([FromBody] UserDto user)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await ser.Register(user);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.Success} {user.Email}");
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
        public async Task<ActionResult<bool>> Delete([FromRoute] long userId)
        {
            var res = await ser.RemoveUser(userId);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.Delete} {userId}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
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
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var res = await ser.GetAllAsync();
            if (res.Any())
            {
                Log.LogInformation($"{SuccessKeys.Success}");
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
        public async Task<ActionResult<UserDto>> GetById([FromRoute] long userId)
        {
            var res = await ser.GetByIdAsync(userId);
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
        /// <param name="useriId">The ID of the user to update.</param>
        /// <param name="user">The updated user data.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        /// <remarks>
        /// Updates an existing user in the system with new data. Returns success or failure.
        /// </remarks>
        [HttpPut]
        [Route("{useriId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Update([FromRoute] long useriId, [FromBody] UserDto user)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await ser.UpdateAsync(useriId, user);
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
