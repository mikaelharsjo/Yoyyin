using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;

namespace Yoyyin.PresentationModel
{
    public interface IUserPresenter
    {
        UserPresentation Presentate(IUser user);
        IEnumerable<UserPresentation> Presentate(IEnumerable<Guid> userGuids);
        IEnumerable<UserPresentation> Presentate(IEnumerable<IUser> users);
    }

    public class UserPresenter : IUserPresenter
    {
        private readonly IUserService _userService;
        public UserPresenter()
        {
            
        }

        public UserPresenter(IUserService userService)
        {
            _userService = userService;
        }

        public UserPresentation Presentate(IUser user)
        {
            return new UserPresentation
                       {
                           Description = user.BusinessDescription.Truncate(330),
                           DisplayName = user.GetDisplayName(),
                           Title = user.BusinessTitle,
                           ProfileUrl = "Member.aspx?UserID=" + user.UserId,
                           UserID = user.UserId
                           //User = user
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