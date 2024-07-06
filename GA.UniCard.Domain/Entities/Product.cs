using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA.UniCard.Domain.Entities
{
    /// <summary>
    /// Represents a product entity.
    /// </summary>
    [Table("Products")]
    [Index(nameof(ProductName), IsDescending = new bool[] { true })]
    public class Product : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [Column("Product_Name")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        [Column("Product_Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        [Column("Product_Price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Navigation property to the order items associated with this product.
        /// </summary>
        public virtual IEnumerable<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
