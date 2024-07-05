using GA.UniCard.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.UniCard.Domain.Configuration
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            Random rand = new Random();
            builder.HasData(
                new OrderItem() { Id=1,OrderId=1,Price=rand.Next(10,100),ProductId=1,Quantity=rand.Next(1,10)},
                   new OrderItem() { Id = 2, OrderId = 2, Price = rand.Next(10, 100), ProductId = 2, Quantity = rand.Next(1, 10) },
                   new OrderItem() { Id = 3, OrderId = 3, Price = rand.Next(10, 100), ProductId = 3, Quantity = rand.Next(1, 10) },
                   new OrderItem() { Id = 4, OrderId = 4, Price = rand.Next(10, 100), ProductId = 4, Quantity = rand.Next(1, 10) },
                   new OrderItem() { Id = 5, OrderId = 5, Price = rand.Next(10, 100), ProductId = 5, Quantity = rand.Next(1, 10) },
                   new OrderItem() { Id = 6, OrderId = 3, Price = rand.Next(10, 100), ProductId = 2, Quantity = rand.Next(1, 10) },
                   new OrderItem() { Id = 7, OrderId = 6, Price = rand.Next(10, 100), ProductId = 4, Quantity = rand.Next(1, 10) }
                );
        }
    }
}
