using System;
using Yoyyin.Domain.Users;

namespace Yoyyin.PresentationModel
{
    public class UserPresentation : IPresentation
    {
        public User User { get; set; }
        public string ProfileUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserID { get; set; }
        public string DisplayName { get; set; }
    }
}