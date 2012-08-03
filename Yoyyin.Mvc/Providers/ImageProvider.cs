using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yoyyin.Mvc.Providers
{
    public class ImageProvider
    {
        public string GetProfileImageSrc(Model.Users.AggregateRoots.IUser user)
        {
            if (user == null) return string.Empty;
            return user.HasImage ? string.Format("/Content/Upload/Images/{0}.jpg", user.UserId) : "/Images/glyphicons_003_user@2x.png";
        }
    }
}