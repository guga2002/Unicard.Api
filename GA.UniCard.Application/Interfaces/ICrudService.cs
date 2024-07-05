using System.Threading.Tasks;

namespace GA.UniCard.Application.Interfaces
{
    /// <summary>
    /// Interface for a service that provides basic CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface ICrudService<T> where T : class
    {
        /// <summary>
        /// Adds a new entity asynchronously.
        /// </summary>
        /// <param name="order">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation, returning true if the operation was successful, otherwise false.</returns>
        Task<bool> AddAsync(T order);

        /// <summary>
        /// Deletes an entity by its unique identifier asynchronously.
        /// </summary>
        /// <param name="orderId">The unique identifier of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation, returning true if the operation was successful, otherwise false.</returns>
        Task<bool> DeleteAsync(long orderId);

        /// <summary>
        /// Updates an entity by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to update.</param>
        /// <param name="order">The updated entity.</param>
        /// <returns>A task that represents the asynchronous operation, returning true if the operation was successful, otherwise false.</returns>
        Task<bool> UpdateAsync(long id, T order);
    }
}
