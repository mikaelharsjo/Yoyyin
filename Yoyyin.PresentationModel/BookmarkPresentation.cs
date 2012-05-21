using Yoyyin.Data.Core.Entities;

namespace Yoyyin.PresentationModel
{
    public class BookmarkPresentation : IPresentation
    {
        public string OnlineImageUrl { get; set; }
        public string DisplayName { get; set; }
        public string ProfileUrl { get; set; }
        public string VisitDate { get; set; }
        public IUser BookmarkedUser { get; set; }
    }
}