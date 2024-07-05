namespace GA.UniCard.Application.Models
{
    /// <summary>
    /// Data transfer object (DTO) for representing a user.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }
    }
}
