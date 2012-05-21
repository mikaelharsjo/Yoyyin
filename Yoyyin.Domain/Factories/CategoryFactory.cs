using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain.QA;

namespace Yoyyin.Domain.Factories
{
    public class CategoryFactory
    {
        private readonly IQuestionRepository _questionRepository;

        public CategoryFactory(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public ICategory CreateCategory(int categoryType)
        {
            return CreateCategory((CategoryType) categoryType);
        }

        public ICategory CreateCategory(CategoryType categoryType)
        {
            switch(categoryType)
            {
                case CategoryType.BusinessIdeas:
                    return new BusinessIdeasCategory(_questionRepository);
                case CategoryType.Friendly:
                    return new FriendlyCategory(_questionRepository);
                case CategoryType.Misc:
                    return new MiscCategory(_questionRepository);
            }

            return new BusinessIdeasCategory(_questionRepository);
        }
    }
}