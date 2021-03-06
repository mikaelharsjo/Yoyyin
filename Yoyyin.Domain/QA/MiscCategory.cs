using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.QA
{
    public class MiscCategory : AbstractCategory
    {
        public MiscCategory(IQuestionRepository repository)
            : base(CategoryType.Misc, repository)
        {
        }
    }
}