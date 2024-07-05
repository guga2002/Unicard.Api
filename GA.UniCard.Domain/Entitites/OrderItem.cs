using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA.UniCard.Domain.Entitites
{
    [Table("Orders")]
    [Index(nameof(OrderId),IsDescending =new bool[] {true})]
    [Index(nameof(ProductId), IsDescending = new bool[] { true })]
    public class OrderItem:AbstractEntity
    {
        [ForeignKey("Order")]
        public long OrderId { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }

        [Column("Item_Quantity")]
        public int Quantity { get; set; }

        [Column("Item_Price")]
        public decimal Price { get; set; }

        public virtual Order ?Order { get; set; }

        public virtual Product? Product { get; set; }
    }
}
