using System.ComponentModel.DataAnnotations;

namespace GA.UniCard.Application.Models.IdentityModel
{
    /// <summary>
    /// Represents a model for user sign-in credentials.
    /// </summary>
    public class SignInModel
    {
        /// <summary>
        /// Gets or sets the username for sign-in.
        /// </summary>
        [Required(ErrorMessage ="The field userName is required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The length of username must be between 5 and 30 characters.")]
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for sign-in.
        /// </summary>
        [Required(ErrorMessage = "The field Password is required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The password must be between 5 and 30 characters.")]
        public required string Password { get; set; }
         
        /// <summary>
        /// Gets or sets a value indicating whether to set a persistent cookie during sign-in.
        /// </summary>
        public bool SetCookie { get; set; }
    }
}
