using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.Services;
using GA.UniCard.Application.StatickFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.UniCard.Api.Controllers
{
    /// <summary>
    /// API controller for managing products.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for CRUD operations on products.
    /// </remarks>
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IproductServices ser;
        private readonly ILogger<ProductController> Log;

        /// <summary>
        /// Constructor for ProductController.
        /// </summary>
        /// <param name="ser">Product services dependency.</param>
        /// <param name="logger">Logger dependency.</param>
        public ProductController(IproductServices ser, ILogger<ProductController> logger)
        {
            this.ser = ser;
            this.Log = logger;
        }

        /// <summary>
        /// Insert a new product.
        /// </summary>
        /// <param name="product">The product to insert.</param>
        /// <returns>True if insertion is successful, otherwise false.</returns>
        /// <remarks>
        /// Inserts a new product into the database. Returns success or failure.
        /// </remarks>
        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ActionResult<bool>> Insert([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await ser.AddAsync(product);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.Success} {product.ProductName}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        /// <summary>
        /// Delete a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        /// <remarks>
        /// Deletes an existing product from the database by its ID. Returns success or failure.
        /// </remarks>
        [HttpDelete]
        [Route("{productId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Delete([FromRoute] long productId)
        {
            var res = await ser.DeleteAsync(productId);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.Delete} {productId}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>A list of all products.</returns>
        /// <remarks>
        /// Retrieves all products from the database. Returns a list of products.
        /// </remarks>
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
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
        /// Get a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID.</returns>
        /// <remarks>
        /// Retrieves a specific product from the database by its ID. Returns the product if found, otherwise returns NotFound.
        /// </remarks>
        [HttpGet]
        [Route("{productId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] long productId)
        {
            var res = await ser.GetByIdAsync(productId);
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
        /// Update a product.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="product">The updated product data.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        /// <remarks>
        /// Updates an existing product in the database with new data. Returns success or failure.
        /// </remarks>
        [HttpPut]
        [Route("{productId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Update([FromRoute] long productId, [FromBody] ProductDto product)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res = await ser.UpdateAsync(productId, product);
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
