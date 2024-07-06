namespace GA.UniCard.Application.Models.IdentityModel
{
    /// <summary>
    /// User Model for registration.
    /// </summary>
    public class RegistrationModel
    {
        /// <summary>
        /// Gets or sets the person details for registration.
        /// </summary>
        public PersonModel Person { get; set; }

        /// <summary>
        /// Gets or sets the password for the user registration.
        /// </summary>
        public string Password { get; set; }
    }
}
