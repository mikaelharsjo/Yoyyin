using Yoyyin.Domain.QA;

namespace Yoyyin.Domain.Mappers
{
    public interface IQAMapper
    {
        QA.Question MapQuestion(Data.Question questionData);
        Answer MapAnswer(Data.Answer answerData);
    }
}