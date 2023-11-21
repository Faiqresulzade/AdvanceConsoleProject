using Core.Models;
using DataAccess.DbContext;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concret
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {

        AppDbContext _appDbContext = new AppDbContext();


        private readonly DbSet<T> _dbset;
        public Repository()
        {
            _dbset = _appDbContext.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetbyIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }
        public async Task CreateAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.AnyAsync(predicate);
        }

        public async Task SaveChanges()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> FirstorDefaultAsync()
        {
            return await _dbset.FirstOrDefaultAsync();
        }
    }
}
