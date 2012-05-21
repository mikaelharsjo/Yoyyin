using System;
using System.Linq;
using System.Linq.Expressions;

namespace Yoyyin.Data.EntityFramework
{
    public class EFSniItemRepository : IRepository<SniItem>
    {
        private readonly YoyyinEntities1 _entities;

        public EFSniItemRepository(YoyyinEntities1 entities)
        {
            _entities = entities;
        }

        public void Delete(SniItem entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SniItem> Find(Expression<Func<SniItem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(SniItem entity)
        {
            throw new NotImplementedException();
        }
    }
}