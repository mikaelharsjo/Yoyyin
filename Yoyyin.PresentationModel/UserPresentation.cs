using System;
using Yoyyin.Data;
using Yoyyin.Domain.Users;

namespace Yoyyin.PresentationModel
{
    public class UserPresentation : IPresentation
    {
        public IUser User { get; set; }
        public string ProfileUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserID { get; set; }
        public string DisplayName { get; set; }
        public byte[] Image { get; set; }
        public string ExternalUrlText { get; set; }
        public string ExternalUrlHref { get; set; }
        public string SniHeadTitle { get; set; }
        public string OnlineImageUrl { get; set; }
        public string PublicProfileUrl { get; set; }
    }
}