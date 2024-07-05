using System.Collections.Generic;
using System.Threading.Tasks;
using GA.UniCard.Domain.Entities;

namespace GA.UniCard.Domain.Interfaces
{
    /// <summary>
    /// Interface for order item repository operations, inheriting CRUD operations.
    /// </summary>
    public interface IOrderItemRepository : ICrudRepository<OrderItem>
    {
    }
}
