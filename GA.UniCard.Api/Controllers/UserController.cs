using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.StatickFiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GA.UniCard.Api.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService ser;
        private readonly ILogger<ProductController> Log;

        public UserController(IUserService ser, ILogger<ProductController> Log)
        {
            this.ser = ser;
            this.Log = Log;
        }

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

        [HttpDelete]
        [Route("{userId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Delete([FromRoute] long userId)
        {
            var res = await ser.RemoveUser(userId);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.delete} {userId}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

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

        [HttpPut]
        [Route("{useriId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Update([FromRoute] long useriId, [FromBody] UserDto User)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await ser.UpdateAsync(useriId, User);
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
