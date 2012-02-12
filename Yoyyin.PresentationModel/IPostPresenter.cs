using System.Collections.Generic;
using Yoyyin.Domain;
using Yoyyin.Domain.QA;

namespace Yoyyin.PresentationModel
{
    public interface IPostPresenter
    {
        IPresentation Presentate(Post post);
        IEnumerable<IPresentation> Presentate(IEnumerable<Post> posts);
    }
}