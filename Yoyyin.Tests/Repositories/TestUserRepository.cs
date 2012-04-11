using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Tests.Repositories
{
    public class TestUserRepository : IUserRepository
    {
        private readonly IList<Data.User> _users;
 
        public TestUserRepository()
        {
            _users = new List<Data.User> { new Data.User { SniHeadID = "A", Name = "Kalle Anka", UserId = new Guid("11111111-1111-1111-1111-111111111111") } };
        }

        public void Add(IUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IUser entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IUser> Find(Expression<Func<IUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IUser> FindAll()
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Guid> GetUserIDsWithMostVisits()
        {
            throw new NotImplementedException();
        }
    }
}