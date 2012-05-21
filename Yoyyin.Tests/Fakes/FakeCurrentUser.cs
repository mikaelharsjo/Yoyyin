using System;
using Yoyyin.Domain.Users;

namespace Yoyyin.Tests.Fakes
{
    public class FakeCurrentUser : ICurrentUser
    {
        public Guid UserId
        {
            get { return Guid.Empty; }
            set { throw new NotImplementedException(); }
        }
    }
}