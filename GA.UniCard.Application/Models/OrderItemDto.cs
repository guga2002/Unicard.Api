using System.ComponentModel.DataAnnotations;

namespace GA.UniCard.Application.Models
{
    /// <summary>
    /// Data transfer object (DTO) for representing an order item.
    /// </summary>
    public class OrderItemDto
    {
        /// <summary>
        /// Gets or sets the ID of the order associated with this order item.
        /// </summary>
        [Required(ErrorMessage = "OrderId is required")]
        public long OrderId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product associated with this order item.
        /// </summary>
        [Required(ErrorMessage = "ProductId is required")]
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in this order item.
        /// </summary>
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price per unit of the product in this order item.
        /// </summary>
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }
    }
}
