using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public class CommentConverter
    {
        public CommentView Convert(Comment comment)
        {
            return new CommentView() { Heading = comment.User.GetDisplayName(), Text = comment.Text };
        }
    }
}