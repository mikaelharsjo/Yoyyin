using System;
using Yoyyin.Domain;
using Yoyyin.Domain.Users;

namespace Yoyyin.Tests.Services
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