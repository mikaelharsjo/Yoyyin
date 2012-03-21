using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.QA
{
    public abstract class AbstractCategory : ICategory
    {
        private readonly CategoryType _categoryType;
        private readonly IQAService _service;

        protected AbstractCategory(CategoryType categoryType, IQAService service)
        {
            _categoryType = categoryType;
            _service = service;
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
            return _service.GetLatestQuestionByCategory(this);
        }

        public IEnumerable<Question> GetQuestions()
        {
            return _service.GetQuestionsByCategory(this);
        }
    }
}