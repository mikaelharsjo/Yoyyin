using System.Collections.Generic;
using Yoyyin.Domain;

namespace Yoyyin.PresentationModel
{
    public interface IQuestionPresenter
    {
        IPresentation Presentate(Question question);
        IEnumerable<IPresentation> Presentate(IEnumerable<Question> shouldBeConverted);
    }
}