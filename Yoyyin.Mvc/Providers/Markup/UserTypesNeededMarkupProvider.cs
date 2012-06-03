using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoyyin.Model.Users.Entities;

namespace Yoyyin.Mvc.Providers.Markup
{
    public class UserTypesNeededMarkupProvider
    {
        public string ToMarkup(UserTypesNeeded userTypesNeeded)
        {
            return string.Join("<br />", userTypesNeeded.UserTypeIds.Select(u => u.ToString()).ToArray());
        }
    }
}