using GA.UniCard.Application.Models.IdentityModel;
using GA.UniCard.Application.Models.ResponseModels;
using GA.UniCard.Domain.Identity.HelperModels;
using Microsoft.AspNetCore.Identity;

namespace GA.UniCard.Application.Interfaces.Identity
{
    /// <summary>
    /// Interface for user-related services.
    /// </summary>
    public interface IPersonServices
    {
        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="user">The model containing user information.</param>
        /// <param name="password">The password for the new user.</param>
        /// <returns>An <see cref="IdentityResult"/> representing the result of the user registration operation.</returns>
        Task<AuthResult> RegisterUserAsync(PersonModel user, string password);

        /// <summary>
        /// Signs in a user asynchronously.
        /// </summary>
        /// <param name="mod">The sign-in model containing user credentials.</param>
        /// <returns>A tuple containing the sign-in result and an optional message.</returns>
         Task<AuthResult> SignInAsync(SignInModel mod);

        /// <summary>
        /// Methods for signed out from system
        /// </summary>
        /// <returns> Boolean, if succesfully  signed out</returns>
        Task<bool> SignOut();


        /// <summary>
        /// For refresh auth token
        /// </summary>
        /// <param name="tok"></param>
        /// <returns></returns>

        Task<AuthResult> RefreshToken(TokenRequest tok);
    }
}
