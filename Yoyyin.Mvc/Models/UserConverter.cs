using System.Linq;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Mvc.Providers.Markup;

namespace Yoyyin.Mvc.Models
{
    public class UserConverter
    {
        private readonly IUserRepository _userRepository;
        private readonly UserTypesNeededMarkupProvider _userTypesNeededMarkupProvider;

        public UserConverter(IUserRepository userRepository, UserTypesNeededMarkupProvider userTypesNeededMarkupProvider)
        {
            _userRepository = userRepository;
            _userTypesNeededMarkupProvider = userTypesNeededMarkupProvider;
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
                           UserTypesNeededMarkup = _userTypesNeededMarkupProvider.ToMarkup((user.Ideas.First().SearchProfile.UserTypesNeeded))
                       };
        }

        // The array is just to avoid unnecesary queries 
        public string[] GetSniArray(Model.Users.AggregateRoots.User user)
        {
            string firstIdeaSniNo = user.Ideas.First().SniNo;
            if (firstIdeaSniNo == null)
                return new string[] { "Övrigt", "Övrigt", "Övrigt" };

            Sni sni = _userRepository.Query(m => m.Snis.First(s => s.SniItem.SniNo == firstIdeaSniNo));
            
            return new string[] { sni.SniHead.Title, sni.SniItem.Title, sni.SniItem.SniNo};
        }
    }
}