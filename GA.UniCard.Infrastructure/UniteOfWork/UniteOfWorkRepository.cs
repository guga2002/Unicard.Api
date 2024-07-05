using GA.UniCard.Domain.Interfaces;
using GA.UniCard.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.UniteOfWork
{
    public class UnitOfWorkRepository : IUniteOfWork
    {
        private readonly IConfiguration Config;

        public UnitOfWorkRepository(IConfiguration Config)
        {
            this.Config = Config;
        }

        private OrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(Config);
                return _orderRepository;
            }
        }

        private OrderItemRepository _orderItemRepository;
        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                if (_orderItemRepository == null)
                    _orderItemRepository = new OrderItemRepository(Config);
                return _orderItemRepository;
            }
        }

        private ProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(Config);
                return _productRepository;
            }
        }

        private UserRepository _userRepository;
        public IUserRepostory UserRepostory
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(Config);
                return _userRepository;
            }
        }
    }
}
