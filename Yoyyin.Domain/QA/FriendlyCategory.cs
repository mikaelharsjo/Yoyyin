using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.QA
{
    public class FriendlyCategory : AbstractCategory
    {
        public FriendlyCategory(IQAService service) : base(CategoryType.Friendly, service)
        {
        }
    }
}