using System.Collections.Generic;
using System.Linq;
using Yoyyin.Model.Users;
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

        public User Convert(Model.Users.AggregateRoots.User user)
        {
            return new User
            {
                DisplayName = user.DisplayName,
                SmallProfileImageSrc = user.HasImage ? string.Format("/Content/Upload/Images/{0}.jpg?width=100&height=100'", user.UserId) : "/Images/glyphicons_003_user@2x.png",
                Competences = user.Competences,
                City = user.Address.City,
                UserType = _userRepository.Query(m => m.UserTypes.First(ut => ut.UserTypeId == user.UserType)).Title,
                UserTypesNeeded = GetUserTypesAsStrings(user),
                CompetencesNeeded = user.Ideas.First().SearchProfile.CompetencesNeeded
            };
        }

        private IEnumerable<string> GetUserTypesAsStrings(Model.Users.AggregateRoots.User user)
        {
            return
                _userRepository.Query(
                    m =>
                    m.UserTypes.Where(
                        ut => user.Ideas.First().SearchProfile.UserTypesNeeded.UserTypeIds.Contains(ut.UserTypeId)))
                    .Select(ut => ut.Title);
        }

        public UserWithFirstIdea ConvertToViewModel(Model.Users.AggregateRoots.User user)
        {
            return new UserWithFirstIdea(GetSniArray(user))
                       {
                           DisplayName = user.DisplayName,
                           FirstIdea = user.Ideas.First(),
                           SmallProfileImageSrc = user.HasImage ? string.Format("/Content/Upload/Images/{0}.jpg?width=100&height=100&mode=crop' />", user.UserId) : "/Images/glyphicons_003_user@2x.png",
                           LargeProfileImageSrc = user.HasImage ? string.Format("/Content/Upload/Images/{0}.jpg?width=200&height=200' />", user.UserId) : "/Images/glyphicons_003_user@2x.png",
                           DetailsHref = string.Format("/User/Details/{0}", user.UserId),
                           UserTypesNeededMarkup = _userTypesNeededMarkupProvider.ToLabelList((user.Ideas.First().SearchProfile.UserTypesNeeded)),
                           CompetencesNeededmarkup = _competencesNeededMarkupProvider.ToLabelList(user.Ideas.First().SearchProfile.CompetencesNeeded),
                           UserTypeMarkup = string.Format("<span class='label label-success'><a href='/User/ListByUserType/{0}/{2}'>{1}</a></span>", user.UserType, GetUserTypeTitle(user), GetUserTypeTitle(user).ToLower().Replace("/", "-")),
                           Latitude = user.Address.Coordinate.Latitude,
                           Longitude = user.Address.Coordinate.Longitude,
                           City = user.Address.City
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
            if (firstIdeaSniNo == "null" || firstIdeaSniNo == "�vrigt")
                return new[] { "�vrigt", "�vrigt", "�vrigt", "�vrigt" };

            var sniHead = _userRepository.Query(m => m.SniHeads.First(s => s.Items.Any(item => item.SniNo == firstIdeaSniNo)));
            
            return new[] { sniHead.Title, sniHead.Items.First().Title, sniHead.Items.First().SniNo, sniHead.SniHeadId};
        }
    }
}