using GA.UniCard.Application.Interfaces.BasicOperations;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.Interfaces
{
    /// <summary>
    /// Interface for a service that provides operations specific to users,
    /// including basic retrieval, registration, user removal, and update operations.
    /// </summary>
    public interface IUserService : IGetService<UserDto>
    {
        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <returns>A task that represents the asynchronous operation, returning true if the registration was successful, otherwise false.</returns>
        Task<bool> Register(UserDto user);

        /// <summary>
        /// Removes a user by their unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the user to remove.</param>
        /// <returns>A task that represents the asynchronous operation, returning true if the removal was successful, otherwise false.</returns>
        Task<bool> RemoveUser(long id);

        /// <summary>
        /// Updates a user by their unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the user to update.</param>
        /// <param name="user">The updated user data.</param>
        /// <returns>A task that represents the asynchronous operation, returning true if the update was successful, otherwise false.</returns>
        Task<bool> UpdateAsync(long id, UserDto user);
    }
}
