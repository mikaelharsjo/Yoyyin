using System.Collections.Generic;
using Yoyyin.Domain;

namespace Yoyyin.PresentationModel
{
    public interface ICommentPresenter
    {
        CommentPresentation Presentate(Comment comment);
        IEnumerable<CommentPresentation> Presentate(IEnumerable<Comment> comments);
    }
}