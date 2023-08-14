using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

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

        public IQueryable<T> GetAsQueryable()
        {
            return _dbSet.AsQueryable();
        }
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate);
        }
        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsQueryable().Where(predicate).ToListAsync();
        }
        public async Task<T?> GetByIdAsync(long id)
        {
           return await _dbSet.FindAsync(id);  
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }  
        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return true;
        }
        public async Task<bool> AddRangeAsync(ICollection<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return true;
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
        public bool DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }
        public bool DeleteRange(IEnumerable<T> entities)
        {
             _dbSet.RemoveRange(entities);
            return true;
        }
        public bool DeleteRange(ICollection<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return true;
        }

    }

}
