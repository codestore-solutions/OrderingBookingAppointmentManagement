using System.Linq.Expressions;

namespace DataAccessLayer.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(long id);
        public Task AddAsync(T entity);
        Task<T> DeleteAsync(long id);
        public void Delete(T entity);
    }
}
