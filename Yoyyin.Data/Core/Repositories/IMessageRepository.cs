using System;
using System.Linq;
using System.Linq.Expressions;

namespace Yoyyin.Data.Core.Repositories
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetOutBoxMessages(Guid userID);
        IQueryable<Message> GetInBoxMessages(Guid userId);
        void Add(Message entity);
        void Delete(Message entity);
        IQueryable<Message> Find(Expression<Func<Message, bool>> predicate);
        IQueryable<Message> FindAll();
    }
}