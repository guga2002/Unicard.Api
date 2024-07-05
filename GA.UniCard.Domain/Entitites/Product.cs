using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA.UniCard.Domain.Entitites
{
    [Table("Products")]
    [Index(nameof(ProductName),IsDescending =new bool[] {true})]
    public class Product:AbstractEntity
    {
        [Column("Product_Name")]
        public required string ProductName { get; set; }

        [Column("Product_Description")]
        public required string Description { get; set; }

        [Column("Product_Price")]
        public decimal Price { get; set; }

        public  virtual IEnumerable<OrderItem> OrderItems { get; set; }

        public Product()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
