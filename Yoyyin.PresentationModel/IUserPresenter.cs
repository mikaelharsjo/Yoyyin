using System;
using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Users;

namespace Yoyyin.PresentationModel
{
    public interface IUserPresenter
    {
        UserPresentation Presentate(IUser user);
        IEnumerable<UserPresentation> Presentate(IEnumerable<Guid> userGuids);
        IEnumerable<UserPresentation> Presentate(IEnumerable<IUser> users);
    }
}