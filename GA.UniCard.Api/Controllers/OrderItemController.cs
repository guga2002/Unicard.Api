using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.Models.ResponseModels;
using GA.UniCard.Application.StaticFiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;

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
    [Authorize(Roles ="CUSTOMER")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemServices orderItemService;
        private readonly ILogger<OrderItemController> logger;
        private readonly IMemoryCache cache;


        /// <summary>
        /// Constructor for OrderItemController.
        /// </summary>
        /// <param name="orderItemService"></param>
        /// <param name="logger"></param>
        /// <param name="cache"></param>
        public OrderItemController(IOrderItemServices orderItemService, ILogger<OrderItemController> logger,IMemoryCache cache)
        {
            this.orderItemService = orderItemService;
            this.logger = logger;
            this.cache = cache;
        }



        /// <summary>
        /// Insert a new order item.
        /// </summary>
        /// <param name="orderItem">The order item to insert.</param>
        /// <returns>True if insertion is successful, otherwise false.</returns>
        /// <remarks>
        /// Inserts a new order item into the database. Returns success or failure.
        /// </remarks>
        [HttpPost]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Insert a new order item V2.0", Description = "Inserts a new order item into the database if it does not already exist. **CUSTOMER**")]
        [SwaggerResponse(200, SuccessKeys.InsertSuccess, typeof(bool))]
        [SwaggerResponse(404, ErrorKeys.BadRequest, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [Authorize(Roles ="CUSTOMER")]
        public async Task<ActionResult<bool>> Insert([FromBody, SwaggerParameter(InfoKeys.orderInfo, Required = true)] OrderItemDto orderItem)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);

            var result = await orderItemService.AddAsync(orderItem);
            if (result)
            {
                logger.LogInformation($"{SuccessKeys.Success} {orderItem.OrderId}");
                return Ok(result);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }



        /// <summary>
        /// Delete an order item by its ID.
        /// </summary>
        /// <param name="orderItemId">The ID of the order item to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        /// <remarks>
        /// Deletes an existing order item from the database by its ID. Returns success or failure.
        /// </remarks>
        [HttpDelete]
        [Route("{orderItemId:long}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Delete an order item V2.0", Description = "Deletes an existing order item from the database by its ID. **CUSTOMER,ADMIN,OPERATOR**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(bool))]
        [SwaggerResponse(404, ErrorKeys.BadRequest, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [Authorize(Roles = "CUSTOMER,ADMIN,OPERATOR")]
        public async Task<ActionResult<bool>> Delete([FromRoute, SwaggerParameter(InfoKeys.OrderId, Required = true)] long orderItemId)
        {
            var result = await orderItemService.DeleteAsync(orderItemId);
            if (result)
            {
                logger.LogInformation($"{SuccessKeys.Delete} {orderItemId}");
                return Ok(result);
            }
            else
            {
                return NotFound(ErrorKeys.UnsuccesfullInsert);
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
        [SwaggerOperation(Summary = "Get all order items V2.0", Description = "Retrieves all order items from the database. **Authorize User** Caching : ** Enable**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(IEnumerable<OrderItemDto>))]
        [SwaggerResponse(404, ErrorKeys.NotFound, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetAll()
        {
                var result = await orderItemService.GetAllAsync();
            if (result.Any())
            {
                logger.LogInformation($"{SuccessKeys.Success}");
                return Ok(result);
            }
            else
            {
                return NotFound(ErrorKeys.NotFound);
            }
        }




        /// <summary>
        /// Get an order item by its ID.
        /// </summary>
        /// <param name="orderItemId">The ID of the order item to retrieve.</param>
        /// <returns>The order item with the specified ID.</returns>
        /// <remarks>
        /// Retrieves a specific order item from the database by its ID. Returns the order item if found, otherwise returns NotFound.
        /// </remarks>
        [HttpGet]
        [Route("{orderItemId:long}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Get an order item by ID V2.0", Description = "Retrieves a specific order item from the database by its ID. **Authorize User** Caching: **Enable**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(OrderItemDto))]
        [SwaggerResponse(404, ErrorKeys.NotFound, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        public async Task<ActionResult<OrderItemDto>> GetById([FromRoute, SwaggerParameter(InfoKeys.OrderId, Required = true)] long orderItemId)
        {
            var result = await orderItemService.GetByIdAsync(orderItemId);
            if (result is null)
            {
                return NotFound(ErrorKeys.NotFound);
            }
            else
            {
                return Ok(result);
            }
        }




        /// <summary>
        /// Update an order item.
        /// </summary>
        /// <param name="orderItemId">The ID of the order item to update.</param>
        /// <param name="orderItem">The updated order item data.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        /// <remarks>
        /// Updates an existing order item in the database with new data. Returns success or failure.
        /// </remarks>
        [HttpPut]
        [Route("{orderItemId:long}")]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Update an order item V2.0", Description = "Updates an existing order item in the database with new data. **CUSTOMER,ADMIN,OPERATOR**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(bool))]
        [SwaggerResponse(404, ErrorKeys.BadRequest, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [Authorize(Roles = "CUSTOMER,ADMIN,OPERATOR")]
        public async Task<ActionResult<bool>> Update([FromRoute, SwaggerParameter("OrderItemId to search for the order item in the database", Required = true)] long orderItemId, [FromBody, SwaggerParameter("OrderItem data to update", Required = true)] OrderItemDto orderItem)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);

            var result = await orderItemService.UpdateAsync(orderItemId, orderItem);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsucessfullUpdate);
            }
        }
    }
}
