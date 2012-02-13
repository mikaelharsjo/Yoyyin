using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.QA
{
    public class CategoryFactory
    {
        public ICategory CreateCategory(int categoryType, IQAService qaService)
        {
            return CreateCategory((CategoryType) categoryType, qaService);
        }

        public ICategory CreateCategory(CategoryType categoryType, IQAService qaService)
        {
            switch(categoryType)
            {
                case CategoryType.BusinessIdeas:
                    return new BusinessIdeasCategory(qaService);
                case CategoryType.Friendly:
                    return new FriendlyCategory(qaService);
                case CategoryType.Misc:
                    return new MiscCategory(qaService);
            }

            return new BusinessIdeasCategory(qaService);
        }
    }
}