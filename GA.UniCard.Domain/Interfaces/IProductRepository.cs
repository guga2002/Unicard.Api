using System.Collections.Generic;
using System.Threading.Tasks;
using GA.UniCard.Domain.Entities;

namespace GA.UniCard.Domain.Interfaces
{
    /// <summary>
    /// Interface for product repository operations, inheriting CRUD operations.
    /// </summary>
    public interface IProductRepository : ICrudRepository<Product>
    {
    }
}
