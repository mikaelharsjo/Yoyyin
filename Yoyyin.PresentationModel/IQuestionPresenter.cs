using System.Collections.Generic;
using Yoyyin.Domain;
using Yoyyin.Domain.QA;

namespace Yoyyin.PresentationModel
{
    public interface IQuestionPresenter
    {
        IPresentation Presentate(Question question);
        IEnumerable<IPresentation> Presentate(IEnumerable<Question> shouldBeConverted);
    }
}