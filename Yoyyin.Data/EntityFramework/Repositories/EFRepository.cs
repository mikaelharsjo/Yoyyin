using System;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Data.EntityFramework.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public ObjectSet<T> ObjectSet;

        public EFRepository(ObjectContext context)
        {
            ObjectSet = context.CreateObjectSet<T>();
        }

        public void Add(T entity)
        {
            ObjectSet.AddObject(entity);
        }

        public void Delete(T entity)
        {
            ObjectSet.DeleteObject(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return ObjectSet.Where(predicate);
        }

        public IQueryable<T> FindAll()
        {
            return ObjectSet;
        }
    }
}
