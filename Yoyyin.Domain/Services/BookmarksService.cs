using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.EntityFramework;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain.Services
{
    public class BookmarksService : IBookmarksService
    {
        private readonly IBookmarkRepository _repository;
        private readonly ICurrentUser _currentUser;

        public BookmarksService(IBookmarkRepository repository, ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public IEnumerable<UserBookmarks> GetBookmarks(Guid userID)
        {
            return _repository
                        .Find()
                        .Where(bookmark => bookmark.UserId == userID)
                        .OrderByDescending(bookmark => bookmark.TimeStamp);
        }

        public void CreateAndSaveBookmark(Guid bookmarkUserID)
        {
            var bookmark = new UserBookmarks { BookmarkedUserID = bookmarkUserID, UserId = _currentUser.UserId, TimeStamp = DateTime.Now };
            _repository.Add(bookmark);

            try
            {
                _repository.Save();
            }
            catch
            {
                // could already be added 
            }
        }

        public void DeleteBookmark(Guid bookmarkUserID)
        {
            UserBookmarks bookmark = _repository
                                        .Find()
                                        .First(userBookmark => userBookmark.UserId == _currentUser.UserId && userBookmark.BookmarkedUserID == bookmarkUserID);
            
            _repository.Delete(bookmark);
            _repository.Save();
        }
    }
}