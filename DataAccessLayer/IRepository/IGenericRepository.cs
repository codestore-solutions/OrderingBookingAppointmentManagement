using System.Linq.Expressions;

namespace DataAccessLayer.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        public Task AddAsync(T entity);
        Task<T> DeleteAsync(long id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IQueryable<T> AsQueryable();
        T FindInList(Func<T, bool> expression);
        Task<IQueryable<T>> AsQueryableAsync();
        Task DeleteEntityAsync(T entity);
        IQueryable<T> Include(params Expression<Func<T, object>> [] includes);
    }
}
