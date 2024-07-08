using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.Models.ResponseModels;
using GA.UniCard.Application.StatickFiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;

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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrderController> logger;
        private readonly IMemoryCache cache;

        /// <summary>
        /// Constructor for OrderController.
        /// </summary>
        /// <param name="orderService"> order services</param>
        /// <param name="logger"> Logger for log informations</param>
        /// <param name="cache"> Memory cash for  cash data</param>
        public OrderController(IOrderService orderService, ILogger<OrderController> logger, IMemoryCache cache)
        {
            this.orderService = orderService;
            this.logger = logger;
            this.cache = cache;
        }


        /// <summary>
        /// Insert a new order.V2.0
        /// </summary>
        /// <param name="order">The order to insert.</param>
        /// <returns>True if insertion is successful, otherwise false.</returns>
        /// <remarks>
        /// Inserts a new order into the database. Returns success or failure.
        /// </remarks>
        [MapToApiVersion("2.0")]
        [HttpPost]
        [SwaggerOperation(Summary = "Insert and place a new order in the system V2.0", Description = "Inserts a new order if it does not already exist. **CUSTOMER**")]
        [SwaggerResponse(200, Description = SuccessKeys.InsertSuccess, Type = typeof(bool))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(bool))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(bool))]
        [Authorize(Roles = "CUSTOMER")]
        public async Task<ActionResult<bool>> Insert([FromBody, SwaggerParameter(InfoKeys.orderInfo, Required = true)] OrderDto order)
        {
            ArgumentNullException.ThrowIfNull(order);
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);

            var result = await orderService.AddAsync(order);
            if (result)
            {
                logger.LogInformation($"{SuccessKeys.Success} {order.OrderDate}");
                return Ok(result);
            }
            else
            {
                logger.LogWarning($"Order insertion failed for order date {order}", order.OrderDate);
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }


        /// <summary>
        /// Delete an order by its ID.V2.0
        /// </summary>
        /// <param name="orderId">The ID of the order to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        /// <remarks>
        /// Deletes an existing order from the database by its ID. Returns success or failure.
        /// </remarks>
        [HttpDelete]
        [Route("{orderId:long}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Delete an order from the database V2.0", Description = "Deletes an order by its ID if it exists. **CUSTOMER,OPERATOR,ADMIN**")]
        [SwaggerResponse(200, Description = SuccessKeys.Success, Type = typeof(bool))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(bool))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        [Authorize(Roles = "CUSTOMER,OPERATOR,ADMIN")]
        public async Task<ActionResult<bool>> Delete([FromRoute, SwaggerParameter(InfoKeys.OrderId, Required = true)] long orderId)
        {
            var result = await orderService.DeleteAsync(orderId);
            if (result)
            {
                logger.LogInformation($"{SuccessKeys.Delete} {orderId}");
                return Ok(result);
            }
            else
            {
                logger.LogWarning($"Order deletion failed for order ID {orderId}", orderId);
                return NotFound(ErrorKeys.UnsuccesfullInsert);
            }
        }



        /// <summary>
        /// Get all orders.V2.0
        /// </summary>
        /// <returns>A list of all orders.</returns>
        /// <remarks>
        /// Retrieves all orders from the database. Returns a list of orders.
        /// </remarks>
        [HttpGet]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Get all order history V2.0", Description = "Retrieves all orders stored by users. **Authorize User** Cashing: **Enable**")]
        [SwaggerResponse(200, Description = SuccessKeys.Success, Type = typeof(IEnumerable<OrderDto>))]
        [SwaggerResponse(404, Description = ErrorKeys.NotFound, Type = typeof(ErrorResponce))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var result = await orderService.GetAllAsync();
            if (result.Any())
            {
                //cache.Set(cashKey, result,TimeSpan.FromMinutes(15));
                logger.LogInformation(SuccessKeys.Success);
                return Ok(result);
            }
            else
            {
                logger.LogWarning("No orders found.");
                return NotFound(ErrorKeys.NotFound);
            }
        }



        /// <summary>
        /// Get an order by its ID.V2.0
        /// </summary>
        /// <param name="orderId">The ID of the order to retrieve.</param>
        /// <returns>The order with the specified ID.</returns>
        /// <remarks>
        /// Retrieves a specific order from the database by its ID. Returns the order if found, otherwise returns NotFound.
        /// </remarks>
        [HttpGet]
        [Route("{orderId:long}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Get order history by ID V2.0", Description = "Retrieves a specific order from the database by its ID. ** Authoorize User** Cashing: **Enable**")]
        [SwaggerResponse(200, Description = SuccessKeys.Success, Type = typeof(OrderDto))]
        [SwaggerResponse(404, Description = ErrorKeys.NotFound, Type = typeof(ErrorResponce))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        public async Task<ActionResult<OrderDto>> GetById([FromRoute, SwaggerParameter(InfoKeys.OrderId, Required = true)] long orderId)
        {
            var result = await orderService.GetByIdAsync(orderId);
            if (result == null)
            {
                logger.LogWarning($"Order not found for ID {orderId}", orderId);
                return NotFound(ErrorKeys.NotFound);
            }
            else
            {
                logger.LogInformation(SuccessKeys.Success);
                return Ok(result);
            }
        }



        /// <summary>
        /// Update an order.V2.0
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
        [SwaggerOperation(Summary = "Update order details V2.0", Description = "Updates an existing order in the database with new data.**CUSTOMER,OPERATOR,ADMIN**")]
        [SwaggerResponse(200, Description = SuccessKeys.Success, Type = typeof(bool))]
        [SwaggerResponse(400, Description = ErrorKeys.BadRequest, Type = typeof(ErrorResponce))]
        [SwaggerResponse(500, Description = ErrorKeys.InternalServerError, Type = typeof(ErrorResponce))]
        [Authorize(Roles = "CUSTOMER,OPERATOR,ADMIN")]
        public async Task<ActionResult<bool>> Update([FromRoute, SwaggerParameter("OrderId for searching order in the database", Required = true)] long orderId, [FromBody, SwaggerParameter("Order data for updating info")] OrderDto order)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);

            var result = await orderService.UpdateAsync(orderId, order);
            if (result)
            {
                logger.LogInformation("Order updated successfully for ID {OrderId}", orderId);
                return Ok(result);
            }
            else
            {
                logger.LogWarning($"Order update failed for ID {orderId}", orderId);
                return BadRequest(ErrorKeys.UnsucessfullUpdate);
            }
        }
    }
}
