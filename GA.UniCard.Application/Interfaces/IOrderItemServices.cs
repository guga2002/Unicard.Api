using GA.UniCard.Application.Interfaces.BasicOperations;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.Interfaces
{
    /// <summary>
    /// Interface for a service that provides operations specific to order items,
    /// including basic retrieval and CRUD operations.
    /// </summary>
    public interface IOrderItemServices : IGetService<OrderItemDto>, ICrudService<OrderItemDto>
    {
        // This interface inherits both IGetService and ICrudService for OrderItemDto.
        // No additional members are defined here.
    }
}
