using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.QA
{
    public class MiscCategory : AbstractCategory
    {
        public MiscCategory(IQAService service) : base(CategoryType.Misc, service)
        {
        }
    }
}