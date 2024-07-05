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
    /// API controller for managing order items.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for CRUD operations on order items.
    /// </remarks>
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemServices ser;
        private readonly ILogger<OrderItemController> Log;

        /// <summary>
        /// Constructor for OrderItemController.
        /// </summary>
        /// <param name="ser">Order item services dependency.</param>
        /// <param name="logger">Logger dependency.</param>
        public OrderItemController(IOrderItemServices ser, ILogger<OrderItemController> logger)
        {
            this.ser = ser;
            this.Log = logger;
        }

        /// <summary>
        /// Insert a new order item.
        /// </summary>
        /// <param name="orderItem">The order item to insert.</param>
        /// <returns>True if insertion is successful, otherwise false.</returns>
        /// <remarks>
        /// Inserts a new order item into the database. Returns success or failure.
        /// </remarks>
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

        /// <summary>
        /// Delete an order item by its ID.
        /// </summary>
        /// <param name="orderitemid">The ID of the order item to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        /// <remarks>
        /// Deletes an existing order item from the database by its ID. Returns success or failure.
        /// </remarks>
        [HttpDelete]
        [Route("{orderitemid:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Delete([FromRoute] long orderitemid)
        {
            var res = await ser.DeleteAsync(orderitemid);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.Delete} {orderitemid}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        /// <summary>
        /// Get all order items.
        /// </summary>
        /// <returns>A list of all order items.</returns>
        /// <remarks>
        /// Retrieves all order items from the database. Returns a list of order items.
        /// </remarks>
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

        /// <summary>
        /// Get an order item by its ID.
        /// </summary>
        /// <param name="orderitemid">The ID of the order item to retrieve.</param>
        /// <returns>The order item with the specified ID.</returns>
        /// <remarks>
        /// Retrieves a specific order item from the database by its ID. Returns the order item if found, otherwise returns NotFound.
        /// </remarks>
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

        /// <summary>
        /// Update an order item.
        /// </summary>
        /// <param name="orderitemid">The ID of the order item to update.</param>
        /// <param name="order">The updated order item data.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        /// <remarks>
        /// Updates an existing order item in the database with new data. Returns success or failure.
        /// </remarks>
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
