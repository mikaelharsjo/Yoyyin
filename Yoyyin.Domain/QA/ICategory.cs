using System.Collections.Generic;
using Yoyyin.Data;

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