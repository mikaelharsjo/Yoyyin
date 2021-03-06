using System.Linq;
using Yoyyin.Model.Users;
using Yoyyin.Mvc.Providers;
using Yoyyin.Mvc.Providers.Markup;
using Yoyyin.Mvc.Services;

namespace Yoyyin.Mvc.ViewModels.Presenters
{
    public class UserPresenter
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypesNeededMarkupProvider _userTypesNeededMarkupProvider;
        private readonly CompetencesNeededMarkupProvider _competencesNeededMarkupProvider;
        private readonly UserTypeService _userTypeService;
        private readonly IdeaPresenter _ideaPresenter;        
        private readonly LookingForPresenter _lookingForPresenter;
        private ImageProvider _imageProvider;

        public UserPresenter(IUserRepository userRepository, IUserTypesNeededMarkupProvider userTypesNeededMarkupProvider, UserTypeService userTypeService, IdeaPresenter ideaPresenter, LookingForPresenter lookingForPresenter)
        {
            _userRepository = userRepository;
            _userTypesNeededMarkupProvider = userTypesNeededMarkupProvider;
            _userTypeService = userTypeService;
            _ideaPresenter = ideaPresenter;
            _lookingForPresenter = lookingForPresenter;
            _competencesNeededMarkupProvider = new CompetencesNeededMarkupProvider();            
        }

        public UserPresenter(UserTypeService userTypeService, IdeaPresenter ideaPresenter)
        {
            _userTypeService = userTypeService;
            _ideaPresenter = ideaPresenter;
        }

        public User Present(Model.Users.AggregateRoots.IUser user)
        {
            _imageProvider = new ImageProvider(user);
            return new User
            {
                id = user.UserId,
                DisplayName = user.DisplayName,
                ProfileImageSrc = _imageProvider.GetProfileImageSrc(),
                Competences = user.Competences,
                City = user.Address.City,
                UserType = _userRepository.Query(m => m.UserTypes.First(ut => ut.UserTypeId == user.UserType)).Title,
                UserTypeId = user.UserType,
                // moved to idea?
                UserTypesNeeded = _userTypeService.GetUserTypesAsStrings(user.Ideas.First().SearchProfile.UserTypesNeeded),
                CompetencesNeeded = user.Ideas.First().SearchProfile.CompetencesNeeded,
                Ideas = user.Ideas.Select(_ideaPresenter.Convert),
                LookingFor = _lookingForPresenter.ToViewModel(user.LookingFor),
                DetailsHref = string.Format("/User/Details/{0}", user.UserId),
                Presentation = user.Presentation
            };
        }

        //// is this used? needs refactoring
        //public UserWithFirstIdea ConvertToViewModel(Model.Users.AggregateRoots.User user)
        //{
        //    _imageProvider = new ImageProvider(user);
        //    return new UserWithFirstIdea(GetSniArray(user))
        //               {
        //                   DisplayName = user.DisplayName,
        //                   FirstIdea = _ideaConverter.Convert(user.Ideas.First()),
        //                   ProfileImageSrc = _imageProvider.GetProfileImageSrc(),    //user.HasImage ? string.Format("/Content/Upload/Images/{0}.jpg?width=70&mode=crop' />", user.UserId) : "/Images/glyphicons_003_user@2x.png",
        //                   //LargeProfileImageSrc = user.HasImage ? string.Format("/Content/Upload/Images/{0}.jpg?width=200&height=200' />", user.UserId) : "/Images/glyphicons_003_user@2x.png",
        //                   DetailsHref = string.Format("/User/Details/{0}", user.UserId),
        //                   UserTypesNeededMarkup = _userTypesNeededMarkupProvider.ToLabelList((user.Ideas.First().SearchProfile.UserTypesNeeded)),
        //                   CompetencesNeededmarkup = _competencesNeededMarkupProvider.ToLabelList(user.Ideas.First().SearchProfile.CompetencesNeeded),
        //                   UserTypeMarkup = string.Format("<span class='label label-success'><a href='/User/ListByUserType/{0}/{2}'>{1}</a></span>", user.UserType, GetUserTypeTitle(user), GetUserTypeTitle(user).ToLower().Replace("/", "-")),
        //                   Latitude = user.Address.Coordinate.Latitude,
        //                   Longitude = user.Address.Coordinate.Longitude,
        //                   City = user.Address.City
        //               };
        //}

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