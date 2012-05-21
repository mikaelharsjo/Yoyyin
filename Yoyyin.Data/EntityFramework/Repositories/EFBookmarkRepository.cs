using System;
using System.Data.Objects;
using System.Linq;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Data.EntityFramework.Repositories
{
    public class EFBookmarkRepository : EFRepository<Bookmark>, IBookmarkRepository //, IMessageRepository
    {
        private readonly ObjectContext _context;

        public EFBookmarkRepository(ObjectContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<IBookmark> GetUserBookmarks(Guid userId)
        {
            return ObjectSet
                .Include("User")
                .Where(b => b.BookmarkedUserID == userId);
        }
    }
}