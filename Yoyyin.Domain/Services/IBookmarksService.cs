using System;
using System.Collections.Generic;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public interface IBookmarksService
    {
        IEnumerable<UserBookmarks> GetBookmarks(Guid userID);
        void CreateAndSaveBookmark(Guid bookmarkUserID);
        void DeleteBookmark(Guid bookmarkUserID);
    }
}