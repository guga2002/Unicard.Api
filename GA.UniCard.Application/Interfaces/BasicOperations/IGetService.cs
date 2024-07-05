using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA.UniCard.Application.Interfaces.BasicOperations
{
    /// <summary>
    /// Interface for a service that provides basic retrieval operations.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface IGetService<T> where T : class
    {
        /// <summary>
        /// Retrieves an entity by its unique identifier asynchronously.
        /// </summary>
        /// <param name="Id">The unique identifier of the entity.</param>
        /// <returns>A task that represents the asynchronous operation, returning the entity.</returns>
        Task<T> GetByIdAsync(long Id);

        /// <summary>
        /// Retrieves all entities of type T asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, returning a collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();
    }
}
