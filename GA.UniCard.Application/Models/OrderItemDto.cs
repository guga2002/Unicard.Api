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
        public long OrderId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product associated with this order item.
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in this order item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price per unit of the product in this order item.
        /// </summary>
        public decimal Price { get; set; }
    }
}
