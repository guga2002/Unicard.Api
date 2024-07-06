using AutoMapper;
using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.Interfaces.Identity;
using GA.UniCard.Application.Models.IdentityModel;
using GA.UniCard.Application.Models.ResponseModels;
using GA.UniCard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonServices"/> class.
        /// </summary>
        /// <param name="userManager">The UserManager instance.</param>
        /// <param name="signInManager">The SignInManager instance.</param>
        /// <param name="map">The AutoMapper instance.</param>
        /// <param name="config">The IConfiguration instance.</param>
        public PersonServices(UserManager<Person> userManager, SignInManager<Person> signInManager, IMapper map, IConfiguration config)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.map = map;
            this.Config = config;
        }

        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="user">The user model to register.</param>
        /// <param name="password">The password for the new user.</param>
        /// <returns>An <see cref="IdentityResult"/> indicating the result of the user registration operation.</returns>
        /// <exception cref="ArgumentException">Thrown when the user already exists or registration fails.</exception>
        public async Task<IdentityResult> RegisterUserAsync(PersonModel user, string password)
        {
            if (await userManager.FindByEmailAsync(user.Email) != null)
                throw new ArgumentException("User already exists in database");

            var mapped = map.Map<Person>(user);
            var result = await userManager.CreateAsync(mapped, password);

            if (!result.Succeeded)
                throw new ArgumentException("Registration failed");

            return result;
        }

        /// <summary>
        /// Signs in a user asynchronously.
        /// </summary>
        /// <param name="mod">The sign-in model containing user credentials.</param>
        /// <returns>A <see cref="SignInResponse"/> containing authentication and refresh token information.</returns>
        /// <exception cref="ArgumentException">Thrown when sign-in fails.</exception>
        public async Task<SignInResponse> SignInAsync(SignInModel mod)
        {
            if (string.IsNullOrEmpty(mod.Username) || string.IsNullOrEmpty(mod.Password))
                throw new UniCardGeneralException("Username or password is empty.");

            var result = await signInManager.PasswordSignInAsync(mod.Username, mod.Password, mod.SetCookie, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var accessToken = await GenerateJwtToken(mod.Username);
                var refreshToken = GenerateRefreshToken();
                var user = await userManager.FindByNameAsync(mod.Username);

                if (user == null)
                    return new SignInResponse() { AuthToken = accessToken, RefreshToken = refreshToken.Token, ValidateTill = refreshToken.ExpiryDate };

                SaveRefreshToken(user.Id, refreshToken);
                return new SignInResponse() { AuthToken = accessToken, RefreshToken = refreshToken.Token, ValidateTill = refreshToken.ExpiryDate };
            }

            throw new ArgumentException("Sign-in was not successful.");
        }

        /// <summary>
        /// Generates a JWT token for the specified username.
        /// </summary>
        /// <param name="username">The username for which to generate the token.</param>
        /// <returns>The generated JWT token as a string.</returns>
        private async Task<string> GenerateJwtToken(string username)
        {
            var jwtSettings = Config.GetSection("JwtSettings");
            var user = await userManager.FindByNameAsync(username) ??
                throw new UnauthorizedAccessException("Access Denied");

            var claims = new[]
            {
                new Claim(ClaimTypes.UserData, username),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? "Not defined"),
                new Claim(ClaimTypes.Email, user.Email ?? "Not defined")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Generates a refresh token with a unique token and expiry date.
        /// </summary>
        /// <returns>The generated <see cref="RefreshTokenModel"/>.</returns>
        private RefreshTokenModel GenerateRefreshToken()
        {
            var refreshToken = new RefreshTokenModel
            {
                Token = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.UtcNow.AddDays(30)
            };

            return refreshToken;
        }

        private Dictionary<string, RefreshTokenModel> _refreshTokens = new Dictionary<string, RefreshTokenModel>();

        /// <summary>
        /// Saves a refresh token for the specified user ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="refreshToken">The refresh token to save.</param>
        private void SaveRefreshToken(string userId, RefreshTokenModel refreshToken)
        {
            _refreshTokens[userId] = refreshToken;
        }
        /// <summary>
        /// method for sign out
        /// </summary>
        /// <returns> return boolean</returns>
        public async Task<bool> SignOut()
        {
          await signInManager.SignOutAsync();
            return true;
        }
    }
}
