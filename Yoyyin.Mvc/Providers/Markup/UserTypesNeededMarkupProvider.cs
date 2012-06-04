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
            return string.Join("<br />", userTypesNeeded.UserTypeIds.Select(u => u.ToString()).ToArray());
        }
    }
}