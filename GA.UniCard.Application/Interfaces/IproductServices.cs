using GA.UniCard.Application.Interfaces.BasicOperations;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.Interfaces
{
    /// <summary>
    /// Interface for a service that provides operations specific to products,
    /// including basic retrieval and CRUD operations.
    /// </summary>
    public interface IproductServices : IGetService<ProductDto>, ICrudService<ProductDto>
    {
        // This interface inherits both IGetService and ICrudService for ProductDto.
        // No additional members are defined here.
    }
}
