using GA.UniCard.Application.Interfaces.BasicOperations;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.Interfaces
{
    /// <summary>
    /// Interface for a service that provides operations specific to orders,
    /// including basic retrieval and CRUD operations.
    /// </summary>
    public interface IOrderService : IGetService<OrderDto>, ICrudService<OrderDto>
    {
        // This interface inherits both IGetService and ICrudService for OrderDto.
        // No additional members are defined here.
    }
}
