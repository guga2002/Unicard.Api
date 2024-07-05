using GA.UniCard.Application.Interfaces.BasicOperations;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.Interfaces
{
    public interface IproductServices:IGetService<ProductDto>,ICrudService<ProductDto>
    {
    }
}
