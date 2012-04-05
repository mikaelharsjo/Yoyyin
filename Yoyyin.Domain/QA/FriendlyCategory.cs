using Yoyyin.Data;
using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.QA
{
    public class FriendlyCategory : AbstractCategory
    {
        public FriendlyCategory(IQuestionRepository repository) : base(CategoryType.Friendly, repository)
        {
        }
    }
}