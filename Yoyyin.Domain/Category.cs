using System.Collections.Generic;
using System.ComponentModel;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;

namespace Yoyyin.Domain
{
    public enum CategoryType
    {
        [Description("Duger din aff�rsid�? Vill du l�sa om andras? Kom in och dela med dig av dina id�er, och f� feedback p� dom fr�n andra medlemmar.")]
        BusinessIdeas,
        [Description("H�r beh�ver inte aff�rsid�en vara hundra genomt�nkt. Feedbacken ska vara positiv. F�rs�k g�rna f�rb�ttra aff�rsid�erna men s�g inte att dom �r d�liga.")]
        Friendly,
        [Description("H�r kan du st�lla valfria fr�gor kring t ex f�retagande, uppstart, aff�rsplan, partnerskap mm.")]
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
                        return "Aff�rsid�er";
                    case CategoryType.Friendly:
                        return "Sn�lla forumet";
                    case CategoryType.Misc:
                        return "�vriga fr�gor";
                    default:
                        return "Detta borde aldrig h�nda";
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