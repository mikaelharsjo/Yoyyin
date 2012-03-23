using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain;

namespace Yoyyin.PresentationModel
{
    public interface ICommentPresenter
    {
        CommentPresentation Presentate(UserComments comment);
        IEnumerable<CommentPresentation> Presentate(IEnumerable<UserComments> comments);
    }
}