using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces.Identity;
using GA.UniCard.Application.Models.ResponseModels;
using GA.UniCard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GA.UniCard.Application.Services.Identity
{
    /// <summary>
    /// Service class providing administrative functionalities for managing roles and users.
    /// </summary>
    public class AdminPanelServices : IAdminPanelServices
    {
        private readonly UserManager<Person> userManager;
        private readonly RoleManager<IdentityRole> role;

        /// <summary>
        /// Constructor for initializing the AdminPanelServices with required services.
        /// </summary>
        /// <param name="userManager">The UserManager instance.</param>
        /// <param name="role">The RoleManager instance.</param>
        public AdminPanelServices(UserManager<Person> userManager,RoleManager<IdentityRole> role)
        {
            this.userManager = userManager;
            this.role = role;
        }

        /// <summary>
        /// Adds a new role to the application.
        /// </summary>
        /// <param name="roleName">The name of the role to add.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        public async Task<IdentityResult> AddRolesAsync(string roleName)
        {
            try
            {
                if (string.IsNullOrEmpty(roleName) || roleName.Length <= 3)
                {
                    throw new UniCardGeneralException(roleName);
                }

                var result = await role.CreateAsync(new IdentityRole(roleName.ToUpper()));
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Checks if a user with the specified email exists in the application.
        /// </summary>
        /// <param name="email">The email address of the user to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public async Task<bool> IsUserExist(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return user != null;
        }

        /// <summary>
        /// Assigns a role to a user identified by their user ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="roleAsync">The role to assign to the user.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        public async Task<IdentityResult> AssignRoleToUserAsync(string userId, string roleAsync)
        {
            if (!await role.RoleExistsAsync(roleAsync))
                return IdentityResult.Success;

            var user = userManager.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return IdentityResult.Success;

            var result = await userManager.AddToRoleAsync(user, roleAsync.ToUpper());
            return result;
        }

        /// <summary>
        /// Deletes a role from the application.
        /// </summary>
        /// <param name="rol">The name of the role to delete.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        public async Task<IdentityResult> DeleteRole(string rol)
        {
            if (!await role.RoleExistsAsync(rol))
                return IdentityResult.Success;

            try
            {
                var roleToDelete = await role.FindByNameAsync(rol.ToUpper());
                if (roleToDelete == null)
                    throw new UniCardGeneralException(rol);

                var result = await role.DeleteAsync(roleToDelete);
                return result;
            }
            catch (DbUpdateConcurrencyException)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Concurrency conflict occurred while deleting role." });
            }
        }

        /// <summary>
        /// Deletes a user from the application.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the operation.</returns>
        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return IdentityResult.Success;

            var result = await userManager.DeleteAsync(user);
            return result;
        }

        /// <summary>
        /// Retrieves all roles defined in the application.
        /// </summary>
        /// <returns>A collection of <see cref="RoleModel"/> representing all roles.</returns>
        public async Task<IEnumerable<RoleModel>> GetAllRoles()
        {
            var roles = await role.Roles
                .Where(r => r.Name != null && r.NormalizedName != null)
                .Select(r => new RoleModel
                {
                    Name = r.Name ?? "Default",
                    NormalizedName = r.NormalizedName ?? "Default",
                })
                .ToListAsync();

            return roles;
        }
    }
}
