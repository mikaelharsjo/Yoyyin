using System.Linq;

namespace Yoyyin.Data.EntityFramework
{
    public class EFSniHeadRepository : IEntitySniHeadRepository
    {
        private readonly YoyyinEntities1 _entities;

        public EFSniHeadRepository(YoyyinEntities1 entities)
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
