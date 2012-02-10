using Yoyyin.Domain.Services;

namespace Yoyyin.Domain
{
    public class BusinessIdeasCategory : AbstractCategory
    {
        public BusinessIdeasCategory(IQAService service) : base(CategoryType.BusinessIdeas, service)
        {
        }
    }
}