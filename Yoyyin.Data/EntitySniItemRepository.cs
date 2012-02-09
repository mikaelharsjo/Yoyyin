using System;
using System.Linq;

namespace Yoyyin.Data
{
    public class EntitySniItemRepository : IRepository<SniItem>
    {
        private readonly YoyyinEntities1 _entities;

        public EntitySniItemRepository(YoyyinEntities1 entities)
        {
            _entities = entities;
        }

        public IQueryable<SniItem> Find()
        {
            return _entities.SniItem;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Delete(SniItem entity)
        {
            throw new NotImplementedException();
        }

        public void Add(SniItem entity)
        {
            throw new NotImplementedException();
        }

        public SniItem Create()
        {
            throw new NotImplementedException();
        }
    }
}