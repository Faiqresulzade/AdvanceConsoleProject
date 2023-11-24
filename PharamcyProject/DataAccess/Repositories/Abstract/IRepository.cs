using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IRepository<T> where T:BaseModel
    {
        List<T> GetAll();
        T GetbyId(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Expression<Func<T, bool>> predicate);
        void SaveChanges();
        T FirstorDefault();
    }
}
