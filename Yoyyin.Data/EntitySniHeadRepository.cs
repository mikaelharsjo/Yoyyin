using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yoyyin.Data
{
    public class EntitySniHeadRepository : IEntitySniHeadRepository
    {
        private readonly YoyyinEntities1 _entities;

        public EntitySniHeadRepository(YoyyinEntities1 entities)
        {
            _entities = entities;
        }

        public IQueryable<SniHead> Find()
        {
            return _entities.SniHead;
        }

        public IQueryable<SniHead> GetAllSniIncludingUsers()
        {
            return _entities
                .SniHead
                .Include("SniItem")
                .Include("User")
                .Where(x => x.User.FirstOrDefault().Active == true);
        }
    }
}
