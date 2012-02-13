using Yoyyin.Domain.Users;

namespace Yoyyin.Domain
{
    public class Bookmark  
    {
        public IUser BookmarkedUser { get; set; }

        public IUser Owner { get; set; }
    }
}