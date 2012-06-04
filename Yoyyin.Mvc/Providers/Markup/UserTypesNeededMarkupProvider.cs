using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoyyin.Model.Users.Entities;

namespace Yoyyin.Mvc.Providers.Markup
{
    public interface IUserTypesNeededMarkupProvider
    {
        string GetMarkup(UserTypesNeeded userTypesNeeded);
    }

    public class UserTypesNeededMarkupProvider : IUserTypesNeededMarkupProvider
    {
        public string GetMarkup(UserTypesNeeded userTypesNeeded)
        {
            return string.Format("<ul>{0}</ul>", string.Join("", userTypesNeeded.UserTypeIds.Select(u => string.Format("<li>{0}</li>", u.ToString())).ToArray()));
        }
    }

    public class StringsToList
    {
        public string ToList(IEnumerable<string> strings)
        {
            return string.Format("<ul>{0}</ul>", string.Join("", strings.Select(s => string.Format("<li>{0}</li>", s.ToString())).ToArray()));
        }

        public string ToLabelList(IEnumerable<string> strings)
        {
            return string.Join(" ", strings.Select(s => string.Format("<span class='label label-info'><a href='/User/ListByCompetence/{0}'>{0}</a></span>", s.ToString())).ToArray());
        }
    }
}