using System.Linq;
using Yoyyin.Model.Extensions;
using Yoyyin.Mvc.Providers;
using Yoyyin.Mvc.Services;

namespace Yoyyin.Mvc.ViewModels.Presenters
{
    public class CurrentUserConverter
    {
        private readonly ImageProvider _imageProvider;
        private readonly SniService _sniService;

        public CurrentUserConverter(SniService sniService)
        {
            _sniService = sniService;
            _imageProvider = new ImageProvider();
        }

        public CurrentUser Convert(Model.Users.AggregateRoots.IUser user)
        {
            return new CurrentUser
                       {
                           Active = user.Active,
                           Address = user.Address,
                           Competences = user.Competences,
                           CVFileName = user.CVFileName,
                           DisplayName = user.DisplayName,
                           Email = user.Email,
                           ProfileImageSrc = _imageProvider.GetProfileImageSrc(user),
                           Ideas = user.Ideas,
                           UserType = _sniService.GetTitle(user.Ideas.First().SniHeadId),
                           Name = user.Name,
                           LastLogin = user.LastLogin.ToFormattedString()
                       };
        }
    }
}