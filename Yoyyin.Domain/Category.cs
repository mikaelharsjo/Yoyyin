using System.Collections.Generic;
using System.ComponentModel;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;

namespace Yoyyin.Domain
{
    public enum CategoryType
    {
        [Description("Duger din affärsidé? Vill du läsa om andras? Kom in och dela med dig av dina idéer, och få feedback på dom från andra medlemmar.")]
        BusinessIdeas,
        [Description("Här behöver inte affärsidéen vara hundra genomtänkt. Feedbacken ska vara positiv. Försök gärna förbättra affärsidéerna men säg inte att dom är dåliga.")]
        Friendly,
        [Description("Här kan du ställa valfria frågor kring t ex företagande, uppstart, affärsplan, partnerskap mm.")]
        Misc
    };

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

    public interface ICategory
    {
        string Title { get; }
        string Description { get; }
        int CategoryId { get; }
        Question GetLatestQuestion();
        IEnumerable<Question> GetQuestions();
    }

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

    public class BusinessIdeasCategory : AbstractCategory
    {
        public BusinessIdeasCategory(IQAService service) : base(CategoryType.BusinessIdeas, service)
        {
        }
    }

    public class FriendlyCategory : AbstractCategory
    {
        public FriendlyCategory(IQAService service) : base(CategoryType.Friendly, service)
        {
        }
    }

    public class MiscCategory : AbstractCategory
    {
        public MiscCategory(IQAService service) : base(CategoryType.Misc, service)
        {
        }
    }
}