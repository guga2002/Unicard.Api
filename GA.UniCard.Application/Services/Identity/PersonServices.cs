using AGRB.Optio.Application.Interfaces.Identity;
using AGRB.Optio.Infrastructure.Identity.HelperModels;
using AutoMapper;
using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces.Identity;
using GA.UniCard.Application.Models.IdentityModel;
using GA.UniCard.Application.Models.ResponseModels;
using GA.UniCard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Application.Services.Identity
{
    /// <summary>
    /// Service class implementing user-related operations.
    /// </summary>
    public class PersonServices : IPersonServices
    {
        private readonly UserManager<Person> userManager;
        private readonly SignInManager<Person> signInManager;
        private readonly IMapper map;
        private readonly IConfiguration Config;
        private readonly IJwtService jwtSer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonServices"/> class.
        /// </summary>
        /// <param name="userManager">The UserManager instance.</param>
        /// <param name="signInManager">The SignInManager instance.</param>
        /// <param name="map">The AutoMapper instance.</param>
        /// <param name="config">The IConfiguration instance.</param>
        public PersonServices(UserManager<Person> userManager, SignInManager<Person> signInManager, IMapper map, IConfiguration config, IJwtService jwtSer)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.map = map;
            this.Config = config;
            this.jwtSer = jwtSer;
        }

        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="user">The user model to register.</param>
        /// <param name="password">The password for the new user.</param>
        /// <returns>An <see cref="IdentityResult"/> indicating the result of the user registration operation.</returns>
        /// <exception cref="ArgumentException">Thrown when the user already exists or registration fails.</exception>
        public async Task<AuthResult> RegisterUserAsync(PersonModel user, string password)
        {
            if (await userManager.FindByEmailAsync(user.Email) != null)
                throw new ArgumentException("User already exists in database");

            var mapped = map.Map<Person>(user);
            var result = await userManager.CreateAsync(mapped, password);

            if (!result.Succeeded)
                throw new ArgumentException("Registration failed");

            var res = await jwtSer.GenerateToken(user.UserName);
            return res;
        }

        /// <summary>
        /// Signs in a user asynchronously.
        /// </summary>
        /// <param name="mod">The sign-in model containing user credentials.</param>
        /// <returns>A <see cref="SignInResponse"/> containing authentication and refresh token information.</returns>
        /// <exception cref="ArgumentException">Thrown when sign-in fails.</exception>
        public async Task<AuthResult> SignInAsync(SignInModel mod)
        {
            if (string.IsNullOrEmpty(mod.Username) || string.IsNullOrEmpty(mod.Password))
                throw new UniCardGeneralException("Username or password is empty.");

            var result = await signInManager.PasswordSignInAsync(mod.Username, mod.Password, mod.SetCookie, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var res = await jwtSer.GenerateToken(mod.Username);

                return res;
            }
            throw new ArgumentException("Sign-in was not successful. no such user exist");
        }

        /// <summary>
        /// Refresh auth token
        /// </summary>
        /// <param name="tok"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<AuthResult> RefreshToken(TokenRequest tok)
        {
            var ver = await jwtSer.VerifyToken(tok);
            if (!ver.Success)
            {
                throw new UnauthorizedAccessException("Refresh token failed");
            }

            var tokenUser = await userManager.FindByIdAsync(ver.UserId);
            AuthResult authResult = await jwtSer.GenerateToken(tokenUser.UserName);
            return authResult;
        }

        /// <summary>
        /// Sign out current user
        /// </summary>
        /// <returns></returns>

        public async Task<bool> SignOut()
        {
          await signInManager.SignOutAsync();
            return true;
        }
    }
}
