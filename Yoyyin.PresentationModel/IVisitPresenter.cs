using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;

namespace Yoyyin.PresentationModel
{
    public interface IVisitPresenter
    {
        IPresentation Presentate(IVisit visit);
        IEnumerable<IPresentation> Presentate(IEnumerable<IVisit> visits);
    }
}