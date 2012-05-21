using System.Linq;

namespace Yoyyin.Data.EntityFramework
{
    public interface IBookmarkRepository
    {
        IQueryable<UserBookmarks> Find();
        void Save();
        void Delete(UserBookmarks entity);
        void Add(UserBookmarks entity);
        UserBookmarks Create();
    }
}