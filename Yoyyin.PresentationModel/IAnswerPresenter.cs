using System.Collections.Generic;
using Yoyyin.Domain;

namespace Yoyyin.PresentationModel
{
    public interface IAnswerPresenter
    {
        AnswerPresentation Presentate(Answer answer);
        IEnumerable<AnswerPresentation> Presentate(IEnumerable<Answer> shouldBeConverted);
    }
}