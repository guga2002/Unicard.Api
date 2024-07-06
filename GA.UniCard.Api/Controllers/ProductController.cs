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
    /// API controller for managing products.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for CRUD operations on products.
    /// </remarks>
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IproductServices productService;
        private readonly ILogger<ProductController> logger;
        private readonly IMemoryCache ceche;

        /// <summary>
        /// Constructor for ProductController.
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="logger"></param>
        /// <param name="ceche"></param>
        public ProductController(IproductServices productService, ILogger<ProductController> logger, IMemoryCache ceche)
        {
            this.productService = productService;
            this.logger = logger;
            this.ceche = ceche;
        }

        /// <summary>
        /// Insert a new product.
        /// </summary>
        /// <param name="product">The product to insert.</param>
        /// <returns>True if insertion is successful, otherwise false.</returns>
        /// <remarks>
        /// Inserts a new product into the database. Returns success or failure.
        /// </remarks>
        [HttpPost]
        [MapToApiVersion("2.0")]
        [SwaggerOperation(Summary = "Insert a new product V2.0", Description = "Inserts a new product into the database if it does not already exist. **ADMIN,OPERATOR**")]
        [SwaggerResponse(200, SuccessKeys.InsertSuccess, typeof(bool))]
        [SwaggerResponse(404, ErrorKeys.BadRequest, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [Authorize(Roles = "ADMIN,OPERATOR")]
        public async Task<ActionResult<bool>> Insert([FromBody, SwaggerParameter(InfoKeys.ProductInfo, Required = true)] ProductDto product)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var result = await productService.AddAsync(product);
            if (result)
            {
                logger.LogInformation($"{SuccessKeys.Success} {product.ProductName}");
                return Ok(result);
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
        [SwaggerOperation(Summary = "Delete a product V2.0", Description = "Deletes an existing product from the database by its ID. **ADMIN,OPERATOR**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(bool))]
        [SwaggerResponse(404, ErrorKeys.BadRequest, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [Authorize(Roles = "ADMIN,OPERATOR")]
        public async Task<ActionResult<bool>> Delete([FromRoute, SwaggerParameter(InfoKeys.ProductId, Required = true)] long productId)
        {
            var result = await productService.DeleteAsync(productId);
            if (result)
            {
                logger.LogInformation($"{SuccessKeys.Delete} {productId}");
                return Ok(result);
            }
            else
            {
                return NotFound(ErrorKeys.UnsuccesfullInsert);
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
        [SwaggerOperation(Summary = "Get all products V2.0", Description = "Retrieves all products from the database. **Authorize User** Caching: **enable**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(IEnumerable<ProductDto>))]
        [SwaggerResponse(404, ErrorKeys.NotFound, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var result = await productService.GetAllAsync();
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
        [SwaggerOperation(Summary = "Get a product by ID V2.0", Description = "Retrieves a specific product from the database by its ID. ** Allow Anymous** Caching: **Enable**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(ProductDto))]
        [SwaggerResponse(404, ErrorKeys.NotFound, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute, SwaggerParameter(InfoKeys.ProductId, Required = true)] long productId)
        {
            var result = await productService.GetByIdAsync(productId);
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
        [SwaggerOperation(Summary = "Update a product V2.0", Description = "Updates an existing product in the database with new data. **ADMIN,OPERATOR**")]
        [SwaggerResponse(200, SuccessKeys.Success, typeof(bool))]
        [SwaggerResponse(404, ErrorKeys.BadRequest, typeof(string))]
        [SwaggerResponse(500, ErrorKeys.InternalServerError, typeof(ErrorResponce))]
        [Authorize(Roles = "ADMIN,OPERATOR")]
        public async Task<ActionResult<bool>> Update([FromRoute, SwaggerParameter(InfoKeys.ProductId, Required = true)] long productId, [FromBody, SwaggerParameter(InfoKeys.ProductInfo, Required = true)] ProductDto product)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var result = await productService.UpdateAsync(productId, product);
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
