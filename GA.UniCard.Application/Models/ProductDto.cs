using System.ComponentModel.DataAnnotations.Schema;

namespace GA.UniCard.Application.Models
{
    public class ProductDto
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
