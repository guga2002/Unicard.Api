using System.ComponentModel.DataAnnotations.Schema;

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
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }
    }
}
