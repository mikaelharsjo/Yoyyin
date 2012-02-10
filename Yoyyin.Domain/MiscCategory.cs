using Yoyyin.Domain.Services;

namespace Yoyyin.Domain
{
    public class MiscCategory : AbstractCategory
    {
        public MiscCategory(IQAService service) : base(CategoryType.Misc, service)
        {
        }
    }
}