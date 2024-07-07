using AGRB.Optio.Infrastructure.Identity.HelperModels;
using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces.Identity;
using GA.UniCard.Application.Models.IdentityModel;
using GA.UniCard.Application.Models.ResponseModels;
using GA.UniCard.Application.StaticFiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GA.UniCard.Api.Controllers
{
    /// <summary>
    /// API controller for user identity operations.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IdentityController : ControllerBase
    {
        private readonly IPersonServices ser;
        private readonly ILogger<IdentityController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityController"/> class.
        /// </summary>
        /// <param name="ser">The user identity service.</param>
        /// <param name="logger">The logger for logging.</param>
        public IdentityController(IPersonServices ser, ILogger<IdentityController> logger)
        {
            this.ser = ser;
            this.logger = logger;
        }

        /// <summary>
        /// Registers a new user to the system.V2.0
        /// </summary>
        /// <param name="identity">Registration model for registering a new user.</param>
        /// <returns>Returns the result of user registration.</returns>
        [HttpPost]
        [Route("[action]")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Register to system V2.0", Description = "Register New User to system **Allow Anymous**")]
        [SwaggerResponse(200, Description = SuccessKeys.InsertSuccess, Type = typeof(IdentityResult))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(string))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResult>> RegisterUser([FromBody, SwaggerParameter("Registration Model For register user", Required = true)] RegistrationModel identity)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelStateException(ErrorKeys.ModelState);
            }
            var res = await ser.RegisterUserAsync(identity.Person, identity.Password);
            if (res is null)
            {
                return BadRequest(ErrorKeys.General);
            }
            return Ok(res);
        }

        /// <summary>
        /// Signs in a user to the system. V2.0
        /// </summary>
        /// <param name="mod">Sign-in model for signing in a user.</param>
        /// <returns>Returns the result of user sign-in.</returns>
        [HttpPost]
        [Route("[action]")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Sign In Endpoint V2.0", Description = "this endpoint is using for user to sign in in system **Allow Anymous**")]
        [SwaggerResponse(200, Description = SuccessKeys.InsertSuccess, Type = typeof(SignInResponse))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(string))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResult>> SignIn([FromBody, SwaggerParameter("Sign In model for User", Required = true)] SignInModel mod)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelStateException(ErrorKeys.ModelState);
            }
            var res = await ser.SignInAsync(mod);
            if (res is null)
            {
                return BadRequest(ErrorKeys.General);
            }
            return Ok(res);
        }

        /// <summary>
        /// Refresh the token. V2.0
        /// </summary>
        /// <param name="mod">Sign-in model for refresh token</param>
        /// <returns>Returns the result of user sign-in.</returns>
        [HttpPost]
        [Route("[action]")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Refresh Token V2.0", Description = "This endpoint is  for update  seasion auth token")]
        [SwaggerResponse(200, Description = SuccessKeys.InsertSuccess, Type = typeof(SignInResponse))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(string))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<AuthResult>> RefreshToken([FromBody, SwaggerParameter("Token refresh parameter", Required = true)] TokenRequest mod)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelStateException(ErrorKeys.ModelState);
            }
            var res = await ser.RefreshToken(mod);
            if (res is null)
            {
                return BadRequest(ErrorKeys.General);
            }
            return Ok(res);
        }


        /// <summary>
        /// Signs out the current user from the system. 
        /// </summary>
        /// <returns>Returns true if sign-out is successful; otherwise, false.</returns>
        [HttpPost]
        [Route("[action]")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Sign Out Endpoint V2.0", Description = "this endpoint is using for user to sign Out from system **Authorized User**")]
        [SwaggerResponse(200, Description = SuccessKeys.InsertSuccess, Type = typeof(bool))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(string))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<bool>> SignOutNow()
        {
            var res = await ser.SignOut();
            if (res)
                return Ok(res);
            return BadRequest(ErrorKeys.General);
        }
    }
}
