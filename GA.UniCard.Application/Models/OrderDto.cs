using System;

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
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the order.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
