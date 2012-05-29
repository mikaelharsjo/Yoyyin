using System.Linq;

namespace Yoyyin.Mvc.Models
{
    public class UserConverter
    {
        public User ConvertToViewModel(Model.Users.AggregateRoots.User user)
        {
            return new User
                       {
                           //SniMarkup = user.Ideas.First().Sni.ToString(),
                           DisplayName = user.DisplayName,
                           FirstIdea = user.Ideas.First(),
                           SmallProfileImageMarkup = string.Format("<img src='/Content/Upload/Images/{0}.jpg?width=100&height=100'", user.UserId)
                       };
        }
    }
}