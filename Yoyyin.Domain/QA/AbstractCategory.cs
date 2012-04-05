using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.QA
{
    public abstract class AbstractCategory : ICategory
    {
        private readonly CategoryType _categoryType;
        private readonly IQuestionRepository _questionRepository;

        protected AbstractCategory(CategoryType categoryType, IQuestionRepository questionRepository)
        {
            _categoryType = categoryType;
            _questionRepository = questionRepository;
        }

        public string Title
        {
            get
            {
                switch (_categoryType)
                {
                    case CategoryType.BusinessIdeas:
                        return "Affärsidéer";
                    case CategoryType.Friendly:
                        return "Snälla forumet";
                    case CategoryType.Misc:
                        return "Övriga frågor";
                    default:
                        return "Detta borde aldrig hända";
                }
            }
        }

        public string Description
        {
            get { return _categoryType.GetDescription(); }
        }

        public int CategoryId
        {
            get { return (int) _categoryType; }
        }

        public Question GetLatestQuestion()
        {
            return _questionRepository
                        .Find(q => q.Category == (int) _categoryType)
                        .OrderByDescending(q => q.Created)
                        .First();
        }

        public IEnumerable<Question> GetQuestions()
        {
            return _questionRepository.Find(q => q.Category == (int) _categoryType);

        }
    }
}