using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Yoyyin.Domain;

namespace Yoyyin.PresentationModel
{
    public interface IVisitPresenter
    {
        IPresentation Presentate(Visit visit);
        IEnumerable<IPresentation> Presentate(IEnumerable<Visit> visits);
    }

    public class VisitPresenter : IVisitPresenter
    {
        public IPresentation Presentate(Visit visit)
        {
            var membershipUser = Membership.GetUser(visit.VisitingUser.UserName);
            return new VisitPresentation
                       {
                           OnlineImageUrl =
                               membershipUser != null && membershipUser.IsOnline
                                   ? "~/Styles/Images/icon_useronline.png"
                                   : "~/Styles/Images/icon_useroffline.png",
                           DisplayName = visit.VisitingUser.GetDisplayName(),
                           ProfileUrl = visit.VisitingUser.GetProfileUrl()
                       };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<Visit> visits)
        {
            return visits.Select(Presentate);
        }
    }
}
