using System;
using System.Data.Objects;
using System.Linq;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Data.EntityFramework.Repositories
{
    public class EFVisitRepository : EFRepository<Visit>, IVisitRepository
    {
        private readonly ObjectContext _context;

        public EFVisitRepository(ObjectContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<Visit> GetUserVisits(Guid userId)
        {
            return ObjectSet
                .Include("User1")
                .Where(v => v.UserId == userId);
        }
    }
}