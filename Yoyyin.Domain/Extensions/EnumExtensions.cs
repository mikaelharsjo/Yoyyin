using System;
using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;

namespace Yoyyin.Domain.Extensions
{
    public static class EnumExtensions
    {

        public static string GetDescription(this Enum enumeration)
        {
            return EnumHelper.GetDescription(enumeration);
        }

        public static string GetTitle(this Enum enumeration)
        {
            if (enumeration is CategoryType)
            {
                var category = (CategoryType) enumeration;
                switch (category)
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
            if (enumeration is UserTypes)
            {
                var userType = (UserTypes)enumeration;
                switch (userType)
                {
                    case UserTypes.Innovator:
                        return "Innovatör/Uppfinnare";
                    case UserTypes.Entrepreneur:
                        return "Företagare/Entreprenör";
                    case UserTypes.Investor:
                        return "Finansiär";
                    case UserTypes.Businessman:
                        return "Företagare";
                    case UserTypes.Retiring:
                        return "Företagare";
                    case UserTypes.Financing:
                        return "Finansiär/Drake/Ängel";
                    default:
                        return "Detta borde aldrig hända";
                }
            }
            if (enumeration is MatchType)
            {
                var userType = (MatchType)enumeration;
                switch (userType)
                {
                    case MatchType.SniItem:
                        return "Bransch";
                    case MatchType.SniHead:
                        return "Affärsområde";
                    case MatchType.SearchWords:
                        return "Sökord (affärsidé)";
                    case MatchType.SearchWordsCompetence:
                        return "Sökord (kompetenser)";
                    case MatchType.UserType:
                        return "Sökes";
                    default:
                        return "Detta borde aldrig hända";
                }
            }

            return "";
        }

        //public static List<Question> GetQuestions(this Category category)
        //{
        //    var service = new QAService(new EFQARepository(new YoyyinEntities1()));

        //    return (List<Question>)service.GetQuestionsByCategory(category);
        //}

        //public static Question GetLatestQuestion(this Category category)
        //{
        //    var service = new QAService(new EFQARepository(new YoyyinEntities1()));

        //    return service.GetLatestQuestionByCategory((int)category);
        //}
    }
}
