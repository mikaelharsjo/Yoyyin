using System;
using System.Linq;
using System.Linq.Expressions;
using Yoyyin.Data.Core.Entities;

namespace Yoyyin.Data.Core.Repositories
{
    public interface IBookmarkRepository
    {
        IQueryable<IBookmark> GetUserBookmarks(Guid userId);
        void Add(Bookmark entity);
        void Delete(Bookmark entity);
        IQueryable<Bookmark> Find(Expression<Func<Bookmark, bool>> predicate);
        IQueryable<Bookmark> FindAll();
    }
}