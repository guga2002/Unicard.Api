using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.StatickFiles;
using Microsoft.AspNetCore.Mvc;

namespace GA.UniCard.Api.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemServices ser;
        private readonly ILogger<OrderItemController> Log;
        public OrderItemController(IOrderItemServices ser, ILogger<OrderItemController> logger)
        {
            this.ser = ser;
            this.Log = logger;
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ActionResult<bool>> Insert([FromBody] OrderItemDto orderItem)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await ser.AddAsync(orderItem);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.Success} {orderItem.OrderId}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        [HttpDelete]
        [Route("{orderitemid:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Delete([FromRoute] long orderitemid)
        {
            var res = await ser.DeleteAsync(orderitemid);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.delete} {orderitemid}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetAll()
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
        [Route("{orderitemid:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<OrderDto>> GetById([FromRoute] long orderitemid)
        {
            var res = await ser.GetByIdAsync(orderitemid);
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
        [Route("{orderitemid:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Update([FromRoute] long orderitemid, [FromBody] OrderItemDto order)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await ser.UpdateAsync(orderitemid, order);
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
