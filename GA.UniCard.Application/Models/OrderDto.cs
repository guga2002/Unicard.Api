namespace GA.UniCard.Application.Models
{
    public class OrderDto
    {
        public long UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

    }
}
