using System.Linq;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Mvc.Providers.Markup;

namespace Yoyyin.Mvc.Models
{
    public class UserConverter
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypesNeededMarkupProvider _userTypesNeededMarkupProvider;
        private readonly CompetencesNeededMarkupProvider _competencesNeededMarkupProvider;

        public UserConverter(IUserRepository userRepository, IUserTypesNeededMarkupProvider userTypesNeededMarkupProvider)
        {
            _userRepository = userRepository;
            _userTypesNeededMarkupProvider = userTypesNeededMarkupProvider;
            _competencesNeededMarkupProvider = new CompetencesNeededMarkupProvider();
        }

        public UserConverter()
        {
        }

        public User ConvertToViewModel(Model.Users.AggregateRoots.User user)
        {
            return new User(GetSniArray(user))
                       {
                           DisplayName = user.DisplayName,
                           FirstIdea = user.Ideas.First(),
                           SmallProfileImageMarkup = user.HasImage ? string.Format("<img src='/Content/Upload/Images/{0}.jpg?width=100&height=100'", user.UserId) : string.Empty,
                           LargeProfileImageMarkup = user.HasImage ? string.Format("<img src='/Content/Upload/Images/{0}.jpg?width=200&height=200'", user.UserId) : string.Empty,
                           DetailsHref = string.Format("/User/Details/{0}", user.UserId),
                           UserTypesNeededMarkup = _userTypesNeededMarkupProvider.ToLabelList((user.Ideas.First().SearchProfile.UserTypesNeeded)),
                           CompetencesNeededmarkup = _competencesNeededMarkupProvider.ToLabelList(user.Ideas.First().SearchProfile.CompetencesNeeded),
                           UserTypeMarkup = string.Format("<span class='label label-success'><a href='/User/ListByUserType/{0}/{2}'>{1}</a></span>", user.UserType, GetUserTypeTitle(user), GetUserTypeTitle(user).ToLower().Replace("/", "-"))
                       };
        }

        private string GetUserTypeTitle(Model.Users.AggregateRoots.User user)
        {
            var userType =
                _userRepository.Query(u => u.UserTypes.First(ut => ut.UserTypeId == user.UserType));
            return userType.Title;
        }

        // The array is just to avoid unnecesary queries 
        public string[] GetSniArray(Model.Users.AggregateRoots.User user)
        {
            string firstIdeaSniNo = user.Ideas.First().SniNo;
            if (firstIdeaSniNo == "null" || firstIdeaSniNo == "Övrigt")
                return new[] { "Övrigt", "Övrigt", "Övrigt", "Övrigt" };

            Sni sni = _userRepository.Query(m => m.Snis.First(s => s.SniItem.SniNo == firstIdeaSniNo));
            
            return new[] { sni.SniHead.Title, sni.SniItem.Title, sni.SniItem.SniNo, sni.SniHead.SniHeadId};
        }
    }
}