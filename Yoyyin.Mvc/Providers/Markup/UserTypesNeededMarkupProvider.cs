using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.Enumerations;

namespace Yoyyin.Mvc.Providers.Markup
{
    public interface IUserTypesNeededMarkupProvider
    {
        string ToList(UserTypesNeeded userTypesNeeded);
        string ToLabelList(UserTypesNeeded userTypesNeeded);
    }

    public class UserTypesNeededMarkupProvider : IUserTypesNeededMarkupProvider
    {
        private readonly LabelListGenerator _labelListGenerator;
        private IUserRepository _userRepository;

        public UserTypesNeededMarkupProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _labelListGenerator = new LabelListGenerator();
        }

        public string ToList(UserTypesNeeded userTypesNeeded)
        {
            return string.Format("<ul>{0}</ul>", string.Join("", userTypesNeeded.UserTypeIds.Select(u => string.Format("<li>{0}</li>", u.ToString())).ToArray()));
        }

        public string ToLabelList(UserTypesNeeded userTypesNeeded)
        {
            //var translatedTitles = userTypesNeeded.GetUserTypeTitles();
            //Dictionary<int, string> userTypesDict = userTypesNeeded.UserTypeIds.ToDictionary(

            // objectify integers
            var userTypes =
                userTypesNeeded.UserTypeIds.Select(
                    userTypeId =>
                    _userRepository.Query(u => u.UserTypes.First(userType => userType.UserTypeId == userTypeId)));
            
            //userType => (int) userType, userType => userType.ToString());

            string formatString =
                "<span class='label label-success'><a href='/User/ListByUserType/{0}/{1}'>{2}</a></span>";

            return string.Join("",
                               userTypes.Select(userType => string.Format(formatString, userType.UserTypeId, userType.Title.ToLower().Replace("/", "-"), userType.Title)).ToArray());
        }
    }
}