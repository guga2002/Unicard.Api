namespace GA.UniCard.Application.Models.ResponseModels
{
    /// <summary>
    /// Represents a refresh token model containing token and expiry date.
    /// </summary>
    public class RefreshTokenModel
    {
        /// <summary>
        /// Gets or sets the refresh token string.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the expiry date of the refresh token.
        /// </summary>
        public DateTime ExpiryDate { get; set; }
    }
}
