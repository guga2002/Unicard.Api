using System.ComponentModel.DataAnnotations;

namespace GA.UniCard.Application.Models
{
    /// <summary>
    /// Data transfer object (DTO) for representing a product.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [Required(ErrorMessage = "ProductName is required")]
        [StringLength(100, ErrorMessage = "ProductName cannot be longer than 100 characters")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }
    }
}
