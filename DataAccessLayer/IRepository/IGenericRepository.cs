using System.Linq.Expressions;

namespace DataAccessLayer.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        public Task AddAsync(T entity);
        Task<T> DeleteAsync(Guid id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IQueryable<T> AsQueryable();
        T FindInList(Func<T, bool> expression);
        Task<IQueryable<T>> AsQueryableAsync();
        public void Delete(T entity);
    }
}
