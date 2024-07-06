using GA.UniCard.Application.Models.ResponseModels;
using Microsoft.AspNetCore.Identity;

namespace GA.UniCard.Application.Interfaces.Identity
{
    /// <summary>
    /// Interface for Admin Panell
    /// </summary>
    public interface IAdminPanelServices
    {
        /// <summary>
        /// Deletes a role from the application.
        /// </summary>
        /// <param name="role">The name of the role to delete.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        Task<IdentityResult> DeleteRole(string role);

        /// <summary>
        /// Adds a new role to the application.
        /// </summary>
        /// <param name="roleName">The name of the role to add.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        Task<IdentityResult> AddRolesAsync(string roleName);

        /// <summary>
        /// Assigns a role to a user identified by their user ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="role">The role to assign to the user.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        Task<IdentityResult> AssignRoleToUserAsync(string userId, string role);

        /// <summary>
        /// Deletes a user from the application.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        Task<IdentityResult> DeleteUser(string id);

        /// <summary>
        /// Retrieves all roles defined in the application.
        /// </summary>
        /// <returns>A collection of <see cref="RoleModel"/> representing all roles.</returns>
        Task<IEnumerable<RoleModel>> GetAllRoles();

        /// <summary>
        /// Checks if a user with the specified email exists in the application.
        /// </summary>
        /// <param name="email">The email address of the user to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        Task<bool> IsUserExist(string email);
    }
}
