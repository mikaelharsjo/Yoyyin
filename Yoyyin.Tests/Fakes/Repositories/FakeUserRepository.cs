using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Tests.Fakes.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly IEnumerable<Data.User> _users;

        public FakeUserRepository()
        {
            _users = new[]
                         {
                             new User {Name = "Kalle"},
                             new User {Name = "Pelle"},
                             new User {Name = "Lasse"}

                         };
        }


        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> FindAll()
        {
            return _users.AsQueryable();
        }

        public IUser GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetLastActiveUsersWithImage()
        {
            throw new NotImplementedException();
        }
    }
}