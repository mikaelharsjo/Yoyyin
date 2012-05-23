using System.Linq;

namespace Yoyyin.Mvc.Models
{
    public class UserConverter
    {
        public User ConvertToViewModel(Model.Users.AggregateRoots.User user)
        {
            return new User
                       {
                           DisplayName = user.DisplayName,
                           FirstIdea = user.Ideas.First(),
                           ProfileImageMarkup = string.Format("<img src='/Content/Upload/Images/{0}.jpg'", user.UserId)
                       };
        }
    }
}