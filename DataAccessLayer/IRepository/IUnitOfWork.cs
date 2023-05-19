
namespace DataAccessLayer.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        public IWishListRepository WishListRepository { get; }
        public IOrderLineRepository OrderLineRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public void Save();
        public Task SaveAsync();
    }
}
