using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public interface IOnlineImageProvider
    {
        string GetOnlineImageUrl(string userName);
    }

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

    public interface IVisitPresenter
    {
        IPresentation Presentate(Visit visit);
        IEnumerable<IPresentation> Presentate(IEnumerable<Visit> visits);
    }

    public class VisitPresenter : IVisitPresenter
    {
        private readonly IOnlineImageProvider _onlineImageProvider;

        public VisitPresenter(IOnlineImageProvider onlineImageProvider)
        {
            _onlineImageProvider = onlineImageProvider;
        }

        public IPresentation Presentate(Visit visit)
        {
            
            return new VisitPresentation
                       {
                           OnlineImageUrl = _onlineImageProvider.GetOnlineImageUrl(visit.VisitingUser.UserName),
                           DisplayName = visit.VisitingUser.GetDisplayName(),
                           ProfileUrl = visit.VisitingUser.GetProfileUrl(),
                           VisitDate = visit.VisitDate.ToFormattedString()
                       };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<Visit> visits)
        {
            return visits.Select(Presentate);
        }
    }
}
