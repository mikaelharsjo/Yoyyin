﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.PresentationModel
{
    public class VisitPresenter : IVisitPresenter
    {
        private readonly IOnlineImageProvider _onlineImageProvider;

        public VisitPresenter(IOnlineImageProvider onlineImageProvider)
        {
            _onlineImageProvider = onlineImageProvider;
        }

        public IPresentation Presentate(IVisit visit)
        {
            return new VisitPresentation
                       {
                           //OnlineImageUrl = _onlineImageProvider.GetOnlineImageUrl(visit.User.UserName),
                           DisplayName = visit.User1.GetDisplayName(),
                           ProfileUrl = visit.User1.GetProfileUrl(),
                           VisitDate = visit.Created.ToFormattedString()
                       };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<IVisit> visits)
        {
            return visits.Select(Presentate);
        }
    }
}
