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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService ser;
        private readonly ILogger<OrderController> Log;
        public OrderController(IOrderService ser, ILogger<OrderController> logger)
        {
            this.ser = ser;
            this.Log = logger;
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ActionResult<bool>> Insert([FromBody] OrderDto order)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await ser.AddAsync(order);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.Success} {order.OrderDate}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        [HttpDelete]
        [Route("{orderId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Delete([FromRoute] long orderId)
        {
            var res = await ser.DeleteAsync(orderId);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.delete} {orderId}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
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
        [Route("{orderId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<OrderDto>> GetById([FromRoute] long orderId)
        {
            var res = await ser.GetByIdAsync(orderId);
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
        [Route("{orderId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Update([FromRoute] long orderId, [FromBody] OrderDto order)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await ser.UpdateAsync(orderId, order);
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
