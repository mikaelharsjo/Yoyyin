namespace Yoyyin.Domain.Services
{
    public class Bookmark  
    {
        public IUser BookmarkedUser { get; set; }

        public IUser Owner { get; set; }
    }
}