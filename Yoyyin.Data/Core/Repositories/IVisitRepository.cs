using System;
using System.Linq;
using System.Linq.Expressions;

namespace Yoyyin.Data.Core.Repositories
{
    public interface IVisitRepository
    {
        IQueryable<Visit> GetUserVisits(Guid userId);
        void Add(Visit entity);
        void Delete(Visit entity);
        IQueryable<Visit> Find(Expression<Func<Visit, bool>> predicate);
        IQueryable<Visit> FindAll();
    }
}