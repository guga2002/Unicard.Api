using System.ComponentModel.DataAnnotations;

namespace GA.UniCard.Application.Models.ResponseModels
{
    /// <summary>
    /// Represents a model for roles in the application.
    /// </summary>
    public class RoleModel
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        [Required(ErrorMessage = "The name field is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the normalized name of the role.
        /// </summary>
        [Required(ErrorMessage = "The normalized name field is required")]
        public string NormalizedName { get; set; }
    }
}
