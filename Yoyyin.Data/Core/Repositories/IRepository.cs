using System;
using System.Linq;
using System.Linq.Expressions;

namespace Yoyyin.Data.Core.Repositories
{
    public interface IRepository<T>
    {   
        void Add(T entity);
        void Delete(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll();
        //T FindById(int id);
    }
}
