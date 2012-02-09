using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public interface IPostPresenter
    {
        IPresentation Presentate(Post post);
        IEnumerable<IPresentation> Presentate(IEnumerable<Post> posts);
    }

    public class PostPresenter : IPresenter<Post>, IPostPresenter
    {
        public IPresentation Presentate(Post post)
        {
            return new PostPresentation
            {
                DisplayName = post.DisplayName,
                Text = post.Text,
                UserId = post.UserId,
                ShortText = post.Text.Truncate(100),
                Date = post.Created.ToFormattedString(),
                Id = post.QuestionId
            };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<Post> posts)
        {
            return posts.Select(Presentate);
        }
    }
}