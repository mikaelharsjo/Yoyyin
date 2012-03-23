using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public interface IVisitPresenter
    {
        IPresentation Presentate(UserVisits visit);
        IEnumerable<IPresentation> Presentate(IEnumerable<UserVisits> visits);
    }

    public class VisitPresenter : IVisitPresenter
    {
        private readonly IOnlineImageProvider _onlineImageProvider;

        public VisitPresenter(IOnlineImageProvider onlineImageProvider)
        {
            _onlineImageProvider = onlineImageProvider;
        }

        public IPresentation Presentate(UserVisits visit)
        {
            return new VisitPresentation
                       {
                           //OnlineImageUrl = _onlineImageProvider.GetOnlineImageUrl(visit.User.UserName),
                           DisplayName = visit.User.GetDisplayName(),
                           ProfileUrl = visit.User.GetProfileUrl(),
                           VisitDate = visit.TimeStamp.ToFormattedString()
                       };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<UserVisits> visits)
        {
            return visits.Select(Presentate);
        }
    }

    public interface IBookmarkPresenter
    {
        IPresentation Presentate(UserBookmarks bookmark);
        IEnumerable<IPresentation> Presentate(IEnumerable<UserBookmarks> bookmarks);
    }

    public class BookmarkPresenter : IBookmarkPresenter
    {
        private readonly IOnlineImageProvider _onlineImageProvider;

        public BookmarkPresenter(IOnlineImageProvider onlineImageProvider)
        {
            _onlineImageProvider = onlineImageProvider;
        }

        public IPresentation Presentate(UserBookmarks bookmark)
        {

            return new BookmarkPresentation
            {
                //OnlineImageUrl = _onlineImageProvider.GetOnlineImageUrl(bookmark.User.UserName),
                DisplayName = bookmark.User.GetDisplayName(),
                ProfileUrl = bookmark.User.GetProfileUrl(),
                BookmarkedUser = (IUser)bookmark.User
            };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<UserBookmarks> bookmarks)
        {
            return bookmarks.Select(Presentate);
        }
    }
}
