using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public class BookmarkPresenter : IBookmarkPresenter
    {
        private readonly IOnlineImageProvider _onlineImageProvider;

        public BookmarkPresenter(IOnlineImageProvider onlineImageProvider)
        {
            _onlineImageProvider = onlineImageProvider;
        }

        public IPresentation Presentate(IBookmark bookmark)
        {

            return new BookmarkPresentation
                       {
                           //OnlineImageUrl = _onlineImageProvider.GetOnlineImageUrl(bookmark.User.UserName),
                           DisplayName = bookmark.User.GetDisplayName(),
                           ProfileUrl = bookmark.User.GetProfileUrl(),
                           BookmarkedUser = (IUser)bookmark.User
                       };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<IBookmark> bookmarks)
        {
            return bookmarks.Select(Presentate);
        }
    }
}