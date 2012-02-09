using System;
using System.Collections.Generic;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public interface IBookmarksService
    {
        IEnumerable<Bookmark> GetBookmarks(Guid userID);
        void CreateAndSaveBookmark(Guid userID, Guid bookmarkUserID);
        void DeleteBookmark(Guid userID, Guid bookmarkUserID);
    }
}