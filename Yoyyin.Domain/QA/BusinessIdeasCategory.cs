using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.QA
{
    public class BusinessIdeasCategory : AbstractCategory
    {
        public BusinessIdeasCategory(IQuestionRepository repository) : base(CategoryType.BusinessIdeas, repository)
        {
        }
    }
}