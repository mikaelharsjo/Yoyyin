using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Web;
using Microsoft.Web;
using Yoyyin.Domain.Services;

namespace Yoyyin.Web.Handlers
{
    public class ImageHandler : Microsoft.Web.ImageHandler
    {
        public IUserService UserService { get; set; }

        public ImageHandler()
        {
            ImageTransforms.Add(new ImageResizeTransform { Width = 70, Mode = ImageResizeMode.Fit });
            EnableClientCache = false;
            EnableServerCache = false;
        }

        public override ImageInfo GenerateImage(NameValueCollection parameters)
        {
            if (parameters["width"] != null)
            {
                ImageTransforms.Clear();
                ImageTransforms.Add(new ImageResizeTransform { Width = int.Parse(parameters["width"]), Mode = ImageResizeMode.Fit });
            }

            if (parameters["height"] != null)
            {
                ImageTransforms.Clear();
                ImageTransforms.Add(new ImageResizeTransform { Width = int.Parse(parameters["width"]), Height = int.Parse(parameters["height"]), Mode = ImageResizeMode.Crop });
            }

            if (parameters["userId"] == null)
            {
                var bitMap = new Bitmap(HttpContext.Current.Server.MapPath("~/Styles/Images/avatarSmall.png"));
                var info = new ImageInfo(bitMap);
                bitMap.Dispose();
                return info;
            }

            Guid userId = new Guid(parameters["userId"]);
            Byte[] image = UserService.GetUser(userId).Image;

            return image != null && image.Length > 0 
                ? new ImageInfo(image) 
                : GetDefaultAvatar();
        }

        private static ImageInfo GetDefaultAvatar()
        {
            string avatarPath = HttpContext.Current.Server.MapPath("~/Styles/Images/avatarSmall.png");
            return new ImageInfo(Image.FromFile(avatarPath));
        }        
    }
}