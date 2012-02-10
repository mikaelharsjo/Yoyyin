using System.Collections.Generic;
using Yoyyin.Domain;

namespace Yoyyin.PresentationModel
{
    public interface IPostPresenter
    {
        IPresentation Presentate(Post post);
        IEnumerable<IPresentation> Presentate(IEnumerable<Post> posts);
    }
}