using System.Web.Security;

namespace Yoyyin.PresentationModel
{
    public class OnlineImageProvider : IOnlineImageProvider
    {
        private const string OfflineImage = "~/Styles/Images/icon_useroffline.png";
        private const string OnlineImage = "~/Styles/Images/icon_useronline.png";

        public string GetOnlineImageUrl(string userName)
        {
            if (userName == null) return OfflineImage;

            var membershipUser = Membership.GetUser(userName);
            return membershipUser != null && membershipUser.IsOnline
                       ? OnlineImage
                       : OfflineImage;
        }
    }
}