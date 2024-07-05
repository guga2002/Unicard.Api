using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GA.UniCard.Domain.Entities
{
    /// <summary>
    /// Represents an order entity.
    /// </summary>
    [Table("Orders")]
    [Index(nameof(UserId), IsDescending = new bool[] {true})]
    public class Order : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the ID of the user who placed the order.
        /// </summary>
        [ForeignKey("User")]
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the order was placed.
        /// </summary>
        [Column("Ordering_Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the order.
        /// </summary>
        [Column("Total_Amount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Navigation property to the User who placed the order.
        /// </summary>
        public virtual User? User { get; set; }

        /// <summary>
        /// Navigation property to the list of items in the order.
        /// </summary>
        public virtual IEnumerable<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
