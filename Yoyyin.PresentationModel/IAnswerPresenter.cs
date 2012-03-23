using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.QA;

namespace Yoyyin.PresentationModel
{
    public interface IAnswerPresenter
    {
        AnswerPresentation Presentate(Answer answer);
        IEnumerable<AnswerPresentation> Presentate(IEnumerable<Answer> shouldBeConverted);
    }
}