using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
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

        public IQueryable<T> GetAllAsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAll(Func<T, bool> predicate)
        {
            return await _dbSet.AsQueryable().ToListAsync();
        }
        public IEnumerable<T> GetByCondtion(Func<T, bool> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate);
        }
        public async Task<T?> GetByIdAsync(long id)
        {
           return await _dbSet.FindAsync(id);  
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }  
        public async Task<T?> DeleteAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            _dbSet.Remove(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

    }

}
