using Yoyyin.Domain.Services;

namespace Yoyyin.Domain
{
    public class FriendlyCategory : AbstractCategory
    {
        public FriendlyCategory(IQAService service) : base(CategoryType.Friendly, service)
        {
        }
    }
}