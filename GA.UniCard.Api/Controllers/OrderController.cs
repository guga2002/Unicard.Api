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
    /// API controller for managing orders.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for CRUD operations on orders.
    /// </remarks>
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService ser;
        private readonly ILogger<OrderController> Log;

        /// <summary>
        /// Constructor for OrderController.
        /// </summary>
        /// <param name="ser">Order service dependency.</param>
        /// <param name="logger">Logger dependency.</param>
        public OrderController(IOrderService ser, ILogger<OrderController> logger)
        {
            this.ser = ser;
            this.Log = logger;
        }

        /// <summary>
        /// Insert a new order.
        /// </summary>
        /// <param name="order">The order to insert.</param>
        /// <returns>True if insertion is successful, otherwise false.</returns>
        /// <remarks>
        /// Inserts a new order into the database. Returns success or failure.
        /// </remarks>
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

        /// <summary>
        /// Delete an order by its ID.
        /// </summary>
        /// <param name="orderId">The ID of the order to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        /// <remarks>
        /// Deletes an existing order from the database by its ID. Returns success or failure.
        /// </remarks>
        [HttpDelete]
        [Route("{orderId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Delete([FromRoute] long orderId)
        {
            var res = await ser.DeleteAsync(orderId);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.Delete} {orderId}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <returns>A list of all orders.</returns>
        /// <remarks>
        /// Retrieves all orders from the database. Returns a list of orders.
        /// </remarks>
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

        /// <summary>
        /// Get an order by its ID.
        /// </summary>
        /// <param name="orderId">The ID of the order to retrieve.</param>
        /// <returns>The order with the specified ID.</returns>
        /// <remarks>
        /// Retrieves a specific order from the database by its ID. Returns the order if found, otherwise returns NotFound.
        /// </remarks>
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

        /// <summary>
        /// Update an order.
        /// </summary>
        /// <param name="orderId">The ID of the order to update.</param>
        /// <param name="order">The updated order data.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        /// <remarks>
        /// Updates an existing order in the database with new data. Returns success or failure.
        /// </remarks>
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
