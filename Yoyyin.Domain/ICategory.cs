using System.Collections.Generic;

namespace Yoyyin.Domain
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