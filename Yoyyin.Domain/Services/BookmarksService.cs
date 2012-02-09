using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public class BookmarksService : IBookmarksService
    {
        private IRepository<Data.UserBookmarks> _repository;
        private IUserService _userService;

        public BookmarksService(IRepository<Data.UserBookmarks> repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public IEnumerable<Bookmark> GetBookmarks(Guid userID)
        {
            return _repository
                .Find()
                .Where(bookmark => bookmark.UserId == userID)
                .OrderByDescending(bookmark => bookmark.TimeStamp)
                .Select(CreateBookmark);
        }

        public Bookmark CreateBookmark(Data.UserBookmarks dataBookmark)
        {
            return new Bookmark
                       {
                           BookmarkedUser = _userService.GetUser(dataBookmark.BookmarkedUserID),
                           Owner = _userService.GetUser(dataBookmark.UserId)
                       };
        }

        public void CreateAndSaveBookmark(Guid userID, Guid bookmarkUserID)
        {
            var bookmark = new UserBookmarks { BookmarkedUserID = bookmarkUserID, UserId = userID, TimeStamp = DateTime.Now };
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

        public void DeleteBookmark(Guid userID, Guid bookmarkUserID)
        {
            UserBookmarks bookmark = _repository
                                        .Find()
                                        .First(userBookmark => userBookmark.UserId == userID && userBookmark.BookmarkedUserID == bookmarkUserID);
            
            _repository.Delete(bookmark);
            _repository.Save();
        }
    }

    public class Bookmark  
    {
        public IUser BookmarkedUser { get; set; }

        public IUser Owner { get; set; }
    }
}