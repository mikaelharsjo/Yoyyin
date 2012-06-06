using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.Enumerations;

namespace Yoyyin.Mvc.Providers.Markup
{
    public interface IUserTypesNeededMarkupProvider
    {
        string ToList(UserTypesNeeded userTypesNeeded);
        string ToLabelList(UserTypesNeeded userTypesNeeded);
    }
    
    public class LabelListGenerator
    {
        public string GenerateMarkup(IEnumerable<string> strings, string formatString)
        {
            return string.Join(" ", strings.Select(s => string.Format(formatString, s.ToString())).ToArray());            
        }
    }

    public class UserTypesNeededMarkupProvider : IUserTypesNeededMarkupProvider
    {
        private readonly LabelListGenerator _labelListGenerator;

        public UserTypesNeededMarkupProvider()
        {
            _labelListGenerator = new LabelListGenerator();
        }

        public string ToList(UserTypesNeeded userTypesNeeded)
        {
            return string.Format("<ul>{0}</ul>", string.Join("", userTypesNeeded.UserTypeIds.Select(u => string.Format("<li>{0}</li>", u.ToString())).ToArray()));
        }

        public string ToLabelList(UserTypesNeeded userTypesNeeded)
        {
            //var translatedTitlesDict = userTypesNeeded.GetUserTypeTitles().ToDictionary(s => s.);
            Dictionary<int, string> userTypesDict = userTypesNeeded.UserTypeIds.ToDictionary(
                userType => (int) userType, userType => userType.ToString());

            string formatString =
                "<span class='label label-success'><a href='/User/ListByUserType/{0}/{1}'>{1}</a></span>";

            return string.Join("",
                               userTypesDict.Select(dict => string.Format(formatString, dict.Key, dict.Value)).ToArray());
        }
    }

    public class CompetencesNeededMarkupProvider
    {
        private readonly LabelListGenerator _labelListGenerator;

        public CompetencesNeededMarkupProvider()
        {
            _labelListGenerator = new LabelListGenerator();
        }

        public string ToList(IEnumerable<string> strings)
        {
            return string.Format("<ul>{0}</ul>", string.Join("", strings.Select(s => string.Format("<li>{0}</li>", s.ToString())).ToArray()));
        }

        public string ToLabelList(IEnumerable<string> strings)
        {
            return _labelListGenerator.GenerateMarkup(strings,
                                                      "<span class='label label-info'><a href='/User/ListByCompetence/{0}'>{0}</a></span>");
        }
    }
}