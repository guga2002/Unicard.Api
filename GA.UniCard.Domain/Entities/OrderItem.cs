using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GA.UniCard.Domain.Entities
{
    /// <summary>
    /// Represents an item in an order.
    /// </summary>
    [Table("OrderItems")]
    [Index(nameof(OrderId), IsDescending = new bool[] { true })]
    [Index(nameof(ProductId), IsDescending = new bool[] { true })]
    public class OrderItem : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the ID of the order to which this item belongs.
        /// </summary>
        [ForeignKey("Order")]
        public long OrderId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product associated with this order item.
        /// </summary>
        [ForeignKey("Product")]
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in this order item.
        /// </summary>
        [Column("Item_Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price of the product in this order item.
        /// </summary>
        [Column("Item_Price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Navigation property to the order to which this item belongs.
        /// </summary>
        public virtual Order? Order { get; set; }

        /// <summary>
        /// Navigation property to the product associated with this order item.
        /// </summary>
        public virtual Product? Product { get; set; }
    }
}
