using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;

namespace Yoyyin.PresentationModel
{
    public interface IBookmarkPresenter
    {
        IPresentation Presentate(IBookmark bookmark);
        IEnumerable<IPresentation> Presentate(IEnumerable<IBookmark> bookmarks);
    }
}