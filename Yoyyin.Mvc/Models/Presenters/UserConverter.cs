using System.Linq;
using Yoyyin.Model.Users;
using Yoyyin.Mvc.Providers;
using Yoyyin.Mvc.Providers.Markup;
using Yoyyin.Mvc.Services;

namespace Yoyyin.Mvc.Models.Presenters
{
    public class UserConverter
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypesNeededMarkupProvider _userTypesNeededMarkupProvider;
        private readonly CompetencesNeededMarkupProvider _competencesNeededMarkupProvider;
        private readonly UserTypeService _userTypeService;
        private readonly IdeaConverter _ideaConverter;
        private readonly ImageProvider _imageProvider;

        public UserConverter(IUserRepository userRepository, IUserTypesNeededMarkupProvider userTypesNeededMarkupProvider, UserTypeService userTypeService, IdeaConverter ideaConverter)
        {
            _userRepository = userRepository;
            _userTypesNeededMarkupProvider = userTypesNeededMarkupProvider;
            _userTypeService = userTypeService;
            _ideaConverter = ideaConverter;
            _competencesNeededMarkupProvider = new CompetencesNeededMarkupProvider();
            _imageProvider = new ImageProvider();
        }

        public UserConverter(UserTypeService userTypeService, IdeaConverter ideaConverter)
        {
            _userTypeService = userTypeService;
            _ideaConverter = ideaConverter;
        }

        public User Convert(Model.Users.AggregateRoots.IUser user)
        {
            return new User
            {
                id = user.UserId,
                DisplayName = user.DisplayName,
                ProfileImageSrc = _imageProvider.GetProfileImageSrc(user),
                Competences = user.Competences,
                City = user.Address.City,
                UserType = _userRepository.Query(m => m.UserTypes.First(ut => ut.UserTypeId == user.UserType)).Title,
                // moved to idea?
                UserTypesNeeded = _userTypeService.GetUserTypesAsStrings(user.Ideas.First().SearchProfile.UserTypesNeeded),
                CompetencesNeeded = user.Ideas.First().SearchProfile.CompetencesNeeded,
                Ideas = user.Ideas.Select(_ideaConverter.Convert)
            };
        }



        public UserWithFirstIdea ConvertToViewModel(Model.Users.AggregateRoots.User user)
        {
            return new UserWithFirstIdea(GetSniArray(user))
                       {
                           DisplayName = user.DisplayName,
                           FirstIdea = _ideaConverter.Convert(user.Ideas.First()),
                           SmallProfileImageSrc = user.HasImage ? string.Format("/Content/Upload/Images/{0}.jpg?width=70&mode=crop' />", user.UserId) : "/Images/glyphicons_003_user@2x.png",
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
            if (firstIdeaSniNo == "null" || firstIdeaSniNo == "Övrigt")
                return new[] { "Övrigt", "Övrigt", "Övrigt", "Övrigt" };

            var sniHead = _userRepository.Query(m => m.SniHeads.First(s => s.Items.Any(item => item.SniNo == firstIdeaSniNo)));
            
            return new[] { sniHead.Title, sniHead.Items.First().Title, sniHead.Items.First().SniNo, sniHead.SniHeadId};
        }
    }
}