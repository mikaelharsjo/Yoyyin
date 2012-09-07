using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Mvc.Providers
{
    public class ImageProvider
    {
        IUser _user;

        public ImageProvider(IUser user)
        {
            _user = user;
        }

        public string GetProfileImageSrc()
        {
            if (_user == null) return string.Empty;
            return _user.HasImage ? GetUploadeImage() : GetAvatar();
        }

        private string GetUploadeImage()
        {
            return string.Format("/Content/Upload/Images/{0}.jpg", _user.UserId);
        }

        private string GetAvatar()
        {
            return "/Images/glyphicons_003_user@2x.png";
        }
    }
}