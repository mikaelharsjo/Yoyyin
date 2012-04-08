using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Users;

namespace Yoyyin.PresentationModel
{
    public class CommentPresenter : ICommentPresenter
    {
        private ICurrentUser _currentUser;

        public CommentPresenter(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public CommentPresentation Presentate(UserComments comment)
        {
            return new CommentPresentation
                       {
                           Heading = comment.User.GetDisplayName(),
                           Text = comment.Text,
                           CellStyle = comment.CommentCommentID != null ? "padding-left: 20px;" : string.Empty,
                           CommentatorUrl = comment.User1.GetProfileUrl(),
                           User = comment.User as IUser,
                           Commentator = comment.User1 as IUser,
                           CommentatorDisplayName = comment.User1.GetDisplayName(),
                           Created = comment.TimeStamp.ToFormattedString(),
                           CommentId = comment.CommentID,
                           DeleteVisible = DeleteVisible(comment)
                       };
        }

        public IEnumerable<CommentPresentation> Presentate(IEnumerable<UserComments> comments)
        {
            return comments.Select(Presentate);
        }

        private bool DeleteVisible(UserComments comment)
        {
            var mu = Membership.GetUser();
            if (mu == null)
                return false;

            // delete allowed
            return comment.User.UserId == _currentUser.UserId;
        }
    }
}