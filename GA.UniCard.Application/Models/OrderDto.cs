using System.ComponentModel.DataAnnotations;

namespace GA.UniCard.Application.Models
{
    /// <summary>
    /// Data transfer object (DTO) for representing an order.
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Gets or sets the ID of the user placing the order.
        /// </summary>
        [Required(ErrorMessage = "UserId is required")]
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the order was placed.
        /// </summary>
        [Required(ErrorMessage = "OrderDate is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date and time format")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the order.
        /// </summary>
        [Required(ErrorMessage = "TotalAmount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be greater than zero")]
        public decimal TotalAmount { get; set; }
    }
}
