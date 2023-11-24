using Core.Models;
using DataAccess.DbContext;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        public List<T> GetAll()
        {
            return  _dbset.ToList();
        }

        public T GetbyId(int id)
        {
            return _dbset.Find(id);
        }
        public void Create(T entity)
        {
             _dbset.Add(entity);
             _appDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
            _appDbContext.SaveChanges();
        }
        public  void Delete(T entity)
        {
            _dbset.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Any(predicate);
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChangesAsync();
        }

        public T FirstorDefault()
        {
            return _dbset.FirstOrDefault();
        }
    }
}
