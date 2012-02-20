using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;

namespace Yoyyin.PresentationModel
{
    public class UserPresenter : IUserPresenter
    {
        private readonly IUserService _userService;
        private readonly IOnlineImageProvider _onlineImageProvider;

        public UserPresenter(IOnlineImageProvider onlineImageProvider)
        {
            _onlineImageProvider = onlineImageProvider;
        }

        public UserPresenter(IUserService userService, IOnlineImageProvider onlineImageProvider)
        {
            _userService = userService;
            _onlineImageProvider = onlineImageProvider;
        }

        public UserPresentation Presentate(IUser user)
        {
            return new UserPresentation
                       {
                           Description = user.BusinessDescription.Truncate(330),
                           DisplayName = user.GetDisplayName(),
                           Title = user.BusinessTitle,
                           ProfileUrl = user.GetProfileUrl(),
                           PublicProfileUrl =  string.Format("http://yoyyin.com/{0}", user.GetDisplayName()),
                           UserID = user.UserId,
                           Image = user.Image,
                           User = user,
                           ExternalUrlText = HttpUtility.HtmlEncode(user.Url),
                           ExternalUrlHref = HttpUtility.UrlPathEncode(string.Format("http://{0}", user.Url.Replace("http://", ""))),
                           SniHeadTitle = user.SniHead.Title,
                           OnlineImageUrl = _onlineImageProvider.GetOnlineImageUrl(user.UserName)
                       };
        }

        public IEnumerable<UserPresentation> Presentate(IEnumerable<IUser> users)
        {
            return users.Select(Presentate);
        }

        public IEnumerable<UserPresentation> Presentate(IEnumerable<Guid> userGuids)
        {
            return userGuids.Select(userGuid => Presentate(_userService.GetUser(userGuid)));
        }
    }

}