namespace GA.UniCard.Application.Models
{
    public class OrderItemDto
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
