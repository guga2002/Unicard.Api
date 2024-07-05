using GA.UniCard.Domain.Configuration;
using GA.UniCard.Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace GA.UniCard.Domain.Data
{
    public class UniCardDbContext:DbContext
    {

        public UniCardDbContext(DbContextOptions<UniCardDbContext>db):base(db)
        {
                
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        }
    }
}
