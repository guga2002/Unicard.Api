using System.ComponentModel.DataAnnotations.Schema;

namespace GA.UniCard.Domain.Entities
{
    /// <summary>
    /// Refresh token for identity
    /// </summary>
    [Table("RefreshTokens")]
    public class RefreshToken:AbstractEntity
    { 
        /// <summary>
        /// Conect to person
        /// </summary>
        [ForeignKey("Person")]
        public string? UserId { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string? Token { get; set; }
        /// <summary>
        /// Jwt ID
        /// </summary>
        public string? JwtId { get; set; }
        /// <summary>
        /// Is used or not
        /// </summary>
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        /// <summary>
        /// Create data
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Expirity
        /// </summary>
        public DateTime ExpiredAt { get; set; }

        /// <summary>
        /// User navigation property
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
