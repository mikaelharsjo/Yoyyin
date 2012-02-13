using System.Collections.Generic;

namespace Yoyyin.Domain.QA
{
    public interface ICategory
    {
        string Title { get; }
        string Description { get; }
        int CategoryId { get; }
        Question GetLatestQuestion();
        IEnumerable<Question> GetQuestions();
    }
}