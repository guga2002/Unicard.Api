using AGRB.Optio.Infrastructure.Identity.HelperModels;

namespace AGRB.Optio.Application.Interfaces.Identity
{
    /// <summary>
    ///  Interface for JWT Services
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Generate Jwt Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<AuthResult> GenerateToken(string user);

        /// <summary>
        /// Verify Jwt Token
        /// </summary>
        /// <param name="tokenRequest"></param>
        /// <returns></returns>
        Task<RefreshTokenResponse> VerifyToken(TokenRequest tokenRequest);

    }
}
