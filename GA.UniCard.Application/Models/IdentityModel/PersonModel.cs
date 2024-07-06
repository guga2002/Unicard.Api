using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(50, ErrorMessage = "UserName cannot be longer than 50 characters")]
        public string UserName { get; set; }

        /// <summary>
        /// Email For Identity Person
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Phone Number For Identity User
        /// </summary>
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Name for Person
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Surname for Person
        /// </summary>
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(50, ErrorMessage = "Surname cannot be longer than 50 characters")]
        public string Surname { get; set; }
    }
}
