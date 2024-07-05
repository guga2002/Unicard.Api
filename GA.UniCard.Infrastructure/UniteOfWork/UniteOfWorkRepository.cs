using GA.UniCard.Domain.Interfaces;
using GA.UniCard.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.UniteOfWork
{
    public class UnitOfWorkRepository : IUniteOfWork
    {
        private readonly IConfiguration Config;
        private readonly string ConnectionString;

        public UnitOfWorkRepository(IConfiguration config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
            ConnectionString = Config.GetConnectionString("DapperConnection")
                                ?? throw new InvalidOperationException("Connection string not found");
        }

        private OrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(ConnectionString);
                return _orderRepository;
            }
        }

        private OrderItemRepository _orderItemRepository;
        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                if (_orderItemRepository == null)
                    _orderItemRepository = new OrderItemRepository(ConnectionString);
                return _orderItemRepository;
            }
        }

        private ProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(ConnectionString);
                return _productRepository;
            }
        }

        private UserRepository _userRepository;
        public IUserRepostory UserRepostory
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(ConnectionString);
                return _userRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.Dispose();

        }
    }
}
