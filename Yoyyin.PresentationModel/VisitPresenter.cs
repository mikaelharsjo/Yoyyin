using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public interface IVisitPresenter
    {
        IPresentation Presentate(Visit visit);
        IEnumerable<IPresentation> Presentate(IEnumerable<Visit> visits);
    }

    public class VisitPresenter : IVisitPresenter
    {
        private readonly IOnlineImageProvider _onlineImageProvider;

        public VisitPresenter(IOnlineImageProvider onlineImageProvider)
        {
            _onlineImageProvider = onlineImageProvider;
        }

        public IPresentation Presentate(Visit visit)
        {
            
            return new VisitPresentation
                       {
                           OnlineImageUrl = _onlineImageProvider.GetOnlineImageUrl(visit.VisitingUser.UserName),
                           DisplayName = visit.VisitingUser.GetDisplayName(),
                           ProfileUrl = visit.VisitingUser.GetProfileUrl(),
                           VisitDate = visit.VisitDate.ToFormattedString()
                       };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<Visit> visits)
        {
            return visits.Select(Presentate);
        }
    }

    public interface IBookmarkPresenter
    {
        IPresentation Presentate(Bookmark bookmark);
        IEnumerable<IPresentation> Presentate(IEnumerable<Bookmark> bookmarks);
    }

    public class BookmarkPresenter : IBookmarkPresenter
    {
        private readonly IOnlineImageProvider _onlineImageProvider;

        public BookmarkPresenter(IOnlineImageProvider onlineImageProvider)
        {
            _onlineImageProvider = onlineImageProvider;
        }

        public IPresentation Presentate(Bookmark bookmark)
        {

            return new BookmarkPresentation
            {
                OnlineImageUrl = _onlineImageProvider.GetOnlineImageUrl(bookmark.BookmarkedUser.UserName),
                DisplayName = bookmark.BookmarkedUser.GetDisplayName(),
                ProfileUrl = bookmark.BookmarkedUser.GetProfileUrl(),
                BookmarkedUser = bookmark.BookmarkedUser
            };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<Bookmark> bookmarks)
        {
            return bookmarks.Select(Presentate);
        }
    }
}
