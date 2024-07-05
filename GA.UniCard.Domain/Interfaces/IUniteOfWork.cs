namespace GA.UniCard.Domain.Interfaces
{
    public interface IUniteOfWork:IDisposable
    {
        public  IOrderRepository OrderRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        public IUserRepostory UserRepostory { get; }
        public IProductRepository ProductRepository { get; }
    }
}
