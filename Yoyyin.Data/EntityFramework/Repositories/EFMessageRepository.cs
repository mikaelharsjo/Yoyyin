using System;
using System.Data.Objects;
using System.Linq;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Data.EntityFramework.Repositories
{
    public class EFMessageRepository : EFRepository<Message>, IMessageRepository
    {
        private readonly ObjectContext _context;

        public EFMessageRepository(ObjectContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<Message> GetOutBoxMessages(Guid userID)
        {
            return ObjectSet
                .Include("User")
                .Include("User1")
                .Where(message => message.FromUserId == userID)
                .OrderBy(message => message.Created);

        }

        public IQueryable<Message> GetInBoxMessages(Guid userId)
        {
            return ObjectSet
                .Include("User")
                .Include("User1")
                .Where(message => message.ToUserId == userId)
                .OrderByDescending(message => message.Created);
        }
    }
}