using System;
using Yoyyin.Domain;

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