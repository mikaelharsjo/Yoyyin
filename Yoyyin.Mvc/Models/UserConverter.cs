using System.Linq;
using Yoyyin.Model.Users;

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
            return new User
                       {
                           SniMarkup = _userRepository.Query(m => m.Snis.First(s => s.SniItem.SniNo == user.Ideas.First().SniNo)).SniItem.Title,
                           DisplayName = user.DisplayName,
                           FirstIdea = user.Ideas.First(),
                           SmallProfileImageMarkup = string.Format("<img src='/Content/Upload/Images/{0}.jpg?width=100&height=100'", user.UserId)
                       };
        }
    }
}