using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA.UniCard.Domain.Entitites
{
    [Table("Orders")]
    [Index(nameof(UserId),IsDescending =new bool[] {true})]
    public class Order:AbstractEntity
    {
        [ForeignKey("User")]
        public long UserId { get; set; }

        [Column("Ordering_Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Column("Total_Amount")]
        public decimal TotalAmount { get; set; }

        public virtual User? User { get; set; }

        public virtual IEnumerable<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
