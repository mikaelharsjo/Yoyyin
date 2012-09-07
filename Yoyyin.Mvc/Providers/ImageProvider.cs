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
            return _user.Image.HasImage ? GetUploadeImage() : GetAvatar();
        }

        private string GetUploadeImage()
        {
            return string.Format("/Content/Upload/Images/{0}.jpg", _user.UserId);
        }

        private string GetAvatar()
        {
            return string.Format("/Images/{0}", string.IsNullOrEmpty(_user.Image.Avatar) ? "glyphicons_003_user@2x.png" : _user.Image.Avatar);
        }
    }
}