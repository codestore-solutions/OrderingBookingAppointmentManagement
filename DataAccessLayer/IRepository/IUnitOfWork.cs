
namespace DataAccessLayer.IRepository
{
    public interface IUnitOfWork: IDisposable
    { 
        public ICartItemsRepository CartItemsRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IWishListRepository WishListRepository { get; }
        public ICartRepository CartRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public void Save();
        public Task SaveAsync();
    }
}
