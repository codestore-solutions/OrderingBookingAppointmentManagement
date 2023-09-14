using System.Linq.Expressions;

namespace DataAccessLayer.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> GetAsQueryable();
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(long id);
        public Task AddAsync(T entity);
        public Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<T?> DeleteAsync(long id);
        public bool DeleteAsync(T entity);
        public bool DeleteRange(IEnumerable<T> entities);
    }
}
