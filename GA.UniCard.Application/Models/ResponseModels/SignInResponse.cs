namespace GA.UniCard.Application.Models.ResponseModels
{
    /// <summary>
    /// Represents a response model for sign-in operations.
    /// </summary>
    public class SignInResponse
    {
        /// <summary>
        /// Gets or sets the authentication token for the signed-in user.
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// Gets or sets the refresh token for the signed-in user.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the expiration date/time until which the authentication token is valid.
        /// </summary>
        public DateTime ValidateTill { get; set; }
    }
}
