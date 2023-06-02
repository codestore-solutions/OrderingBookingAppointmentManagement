using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OrderDbContext dbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(OrderDbContext dbContext)
        {
            this.dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task<T> DeleteAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            _dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteEntityAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }
        public T FindInList(Func<T,bool> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }
        public async Task<IQueryable<T>> AsQueryableAsync()
        {
            return await Task.FromResult(_dbSet.AsQueryable());
        }
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

    }

}
