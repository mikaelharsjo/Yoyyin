using System;
using System.Linq;
using System.Linq.Expressions;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Tests.Services
{
    public class FakeVisitRepository : IVisitRepository
    {
        public IQueryable<Visit> GetUserVisits(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Add(Visit entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Visit entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Visit> Find(Expression<Func<Visit, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Visit> FindAll()
        {
            User user1 = new User {Name = "Kalle"};
            User user2 = new User {Name = "Pelle"};
            User user3 = new User {Name = "Lasse"};

            return
                new[]
                    {
                        new Visit {User = user1, User1 = user2}, new Visit {User = user1, User1 = user3},
                        new Visit {User = user3, User1 = user2}
                    }
                    .AsQueryable();

        }
    }
}