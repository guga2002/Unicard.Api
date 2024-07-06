namespace GA.UniCard.Application.Models.IdentityModel
{
    /// <summary>
    /// Person Model for Identity
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// UserName For Identity
        /// </summary>
        public required string UserName { get; set; }

        /// <summary>
        /// Email For Identity Person
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Phone Number For Identity User
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Name for Person
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Surname for Person
        /// </summary>
        public required string Surname { get; set; }
    }
}
