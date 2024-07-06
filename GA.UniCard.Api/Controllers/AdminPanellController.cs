using GA.UniCard.Application.Interfaces.Identity;
using GA.UniCard.Application.Models.ResponseModels;
using GA.UniCard.Application.StaticFiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GA.UniCard.Api.Controllers
{
    /// <summary>
    /// API controller for administrative Exercises.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [Authorize(Roles ="ADMIN")]
    public class AdminPanellController : ControllerBase
    {
        private readonly IAdminPanelServices adminPanelServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminPanellController"/> class.
        /// </summary>
        /// <param name="adminPanelServices">The admin panel services.</param>
        public AdminPanellController(IAdminPanelServices adminPanelServices)
        {
            this.adminPanelServices = adminPanelServices;
        }

        /// <summary>
        /// Deletes a role from the application. V2.0
        /// </summary>
        /// <param name="role">The name of the role to delete.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        [HttpPost]
        [Route("{role:alpha}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Delete Role Endpoint V2.0", Description = "Deletes a role from the application. **ADMIN**")]
        [SwaggerResponse(200, Description = SuccessKeys.InsertSuccess, Type = typeof(IdentityResult))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(string))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<IdentityResult>> DeleteRole(string role)
        {
            var result = await adminPanelServices.DeleteRole(role);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(ErrorKeys.General);
        }

        /// <summary>
        /// Adds a new role to the application. V2.0
        /// </summary>
        /// <param name="roleName">The name of the role to add.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        [HttpPost]
        [Route("{roleName:alpha}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Add Role Endpoint V2.0", Description = "Adds a new role to the application. **ADMIN**")]
        [SwaggerResponse(200, Description = SuccessKeys.InsertSuccess, Type = typeof(IdentityResult))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(string))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<IdentityResult>> AddRole(string roleName)
        {
            var result = await adminPanelServices.AddRolesAsync(roleName);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(ErrorKeys.General);
        }

        /// <summary>
        /// Assigns a role to a user identified by their user ID. V2.0
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="role">The role to assign to the user.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        [HttpPost]
        [Route("[action]/{role:alpha}/{userId:alpha}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Assign Role Endpoint V2.0", Description = "Assigns a role to a user identified by their user ID. **ADMIN**")]
        [SwaggerResponse(200, Description = SuccessKeys.InsertSuccess, Type = typeof(IdentityResult))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(string))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<IdentityResult>> AssignRoleToUser(string userId, string role)
        {
            var result = await adminPanelServices.AssignRoleToUserAsync(userId, role);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(ErrorKeys.General);
        }

        /// <summary>
        /// Deletes a user from the application. V2.0
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        [HttpPost]
        [Route("{id:alpha}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Delete User Endpoint V2.0", Description = "Deletes a user from the application. **ADMIN**")]
        [SwaggerResponse(200, Description = SuccessKeys.Success, Type = typeof(IdentityResult))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(string))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<IdentityResult>> DeleteUser(string id)
        {
            var result = await adminPanelServices.DeleteUser(id);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(ErrorKeys.General);
        }

        /// <summary>
        /// Retrieves all roles defined in the application. V2.0
        /// </summary>
        /// <returns>A collection of <see cref="RoleModel"/> representing all roles.</returns>
        [HttpGet]
        [Route("[action]")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Get All Roles Endpoint V2.0", Description = "Retrieves all roles defined in the application. **ADMIN**")]
        [SwaggerResponse(200, Description = SuccessKeys.Success, Type = typeof(IEnumerable<RoleModel>))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<IEnumerable<RoleModel>>> GetAllRoles()
        {
            var roles = await adminPanelServices.GetAllRoles();
            if (roles.Any())
            {
                return Ok(roles);
            }
            return BadRequest(ErrorKeys.General);
        }

        /// <summary>
        /// Checks if a user with the specified email exists in the application.V2.0
        /// </summary>
        /// <param name="email">The email address of the user to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        [HttpGet]
        [Route("{email:alpha}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Check User Existence Endpoint V2.0", Description = "Checks if a user with the specified email exists in the application. **ADMIN**")]
        [SwaggerResponse(200, Description = SuccessKeys.Success, Type = typeof(bool))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<bool>> IsUserExist(string email)
        {
            var exists = await adminPanelServices.IsUserExist(email);
            return Ok(exists);
        }
    }
}
