using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.QA
{
    public class BusinessIdeasCategory : AbstractCategory
    {
        public BusinessIdeasCategory(IQAService service) : base(CategoryType.BusinessIdeas, service)
        {
        }
    }
}