using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain.Mappers
{
    public class VisitMapper : IVisitMapper
    {
        private readonly IUserMapper _userMapper;

        public VisitMapper(IUserMapper userMapper)
        {
            _userMapper = userMapper;
        }

        public Visit MapVisit(Data.UserVisits visit)
        {
            return new Visit
                       {
                           VisitingUser =
                               visit.VisitingUserId != null ? _userMapper.MapUser(visit.User) : new AnonymousUser()
                       };
        }
    }
}
