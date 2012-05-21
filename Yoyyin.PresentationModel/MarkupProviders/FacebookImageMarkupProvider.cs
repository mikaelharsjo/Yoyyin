using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yoyyin.Data.Core.Entities;

namespace Yoyyin.PresentationModel.MarkupProviders
{
    public class FacebookImageMarkupProvider
    {
        private readonly IUser _user;
        public const string FacebookImageurlSmall = "https://graph.facebook.com/{0}/picture";

        public FacebookImageMarkupProvider(IUser user)
        {
            _user = user;
        }

        public static bool ShowFaceBookImage(IUser user)
        {
            bool hasFacebook = !string.IsNullOrEmpty(user.FacebookID);
            bool hasYoyyinImage = user.Image != null;
            return hasFacebook && !hasYoyyinImage;
        }

        public string GetMarkup()
        {
            return ShowFaceBookImage(_user) ? string.Format(FacebookImageurlSmall, _user.FacebookID) : string.Empty;
        }
    }
}
