using System.Linq;
using System.Threading.Tasks;
using ApiBookLibrary.Models;
using ApiBookLibrary.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace ApiBookLibrary.Repository
{
    public abstract class GenericRepository<T> : IGenericrepository<T>
        where T : ClassBase, new()

    {

        protected BookLibraryDataContext _dbContext {get;set;}
        public async Task DeleteAsync(int id)
        {
            T entity = new T() {Id = id};

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
            
        }

        public async Task InsertAsync(T entity)
        {
            entity.DateChanged = DateTime.UtcNow;
            entity.DateCreated = DateTime.UtcNow;

            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> Query()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.DateChanged = DateTime.UtcNow;

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }
    }
}