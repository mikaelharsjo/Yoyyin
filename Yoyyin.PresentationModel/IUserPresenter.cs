using System;
using System.Collections.Generic;
using Yoyyin.Domain;

namespace Yoyyin.PresentationModel
{
    public interface IUserPresenter
    {
        UserPresentation Presentate(IUser user);
        IEnumerable<UserPresentation> Presentate(IEnumerable<Guid> userGuids);
        IEnumerable<UserPresentation> Presentate(IEnumerable<IUser> users);
    }
}