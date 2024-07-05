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
    public class ProductController : ControllerBase
    {

        private readonly IproductServices ser;
        private readonly ILogger<ProductController> Log;

        public ProductController(IproductServices ser, ILogger<ProductController> Log)
        {
            this.ser = ser;
            this.Log = Log;
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ActionResult<bool>> Insert([FromBody]ProductDto product)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res=await ser.AddAsync(product);
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

        [HttpDelete]
        [Route("{productId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Delete([FromRoute]long productId)
        {
            var res=await ser.DeleteAsync(productId);
            if (res)
            {
                Log.LogInformation($"{SuccessKeys.delete} {productId}");
                return Ok(res);
            }
            else
            {
                return BadRequest(ErrorKeys.UnsuccesfullInsert);
            }
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
          var res=await ser.GetAllAsync();
            if(res.Any())
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
        [Route("{productId:long}")]
        [MapToApiVersion("2.0")]    
        public async Task<ActionResult<ProductDto>> GetById([FromRoute]long productId)
        {
            var res= await ser.GetByIdAsync(productId);
            if(res is null)
            {
                return NotFound(ErrorKeys.NotFound);
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPut]
        [Route("{productId:long}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<bool>> Update([FromRoute]long productId, [FromBody]ProductDto product)
        {
            if (!ModelState.IsValid) throw new ModelStateException(ErrorKeys.ModelState);
            var res=await ser.UpdateAsync(productId, product);
            if(res)
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
