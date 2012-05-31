using System.Linq;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Mvc.Models
{
    public class UserConverter
    {
        private readonly IUserRepository _userRepository;

        public UserConverter(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
                           SmallProfileImageMarkup = string.Format("<img src='/Content/Upload/Images/{0}.jpg?width=100&height=100'", user.UserId)
                       };
        }

        // The array is just to avoid unnecesary queries 
        public string[] GetSniArray(Model.Users.AggregateRoots.User user)
        {
            string firstIdeaSniNo = user.Ideas.First().SniNo;
            if (firstIdeaSniNo == null)
                return new string[] { string.Empty, string.Empty };

            Sni sni = _userRepository.Query(m => m.Snis.First(s => s.SniItem.SniNo == firstIdeaSniNo));
            return new string[] { sni.SniHead.Title, sni.SniItem.Title };
        }
    }
}