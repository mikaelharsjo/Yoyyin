using System.Collections.Generic;
using System.Linq;

namespace Yoyyin.Domain.EntityHelpers
{
    public class SniHelper : EntityBase
    {
        public List<SniHead> GetAllSniHeadItems()
        {
            return Entities.SniHead.ToList();
        }

        public IEnumerable<SniHead> GetAllSniIncludingUsers()
        {
            return Entities
                .SniHead
                .Include("SniItem")
                .Include("User")
                .Where(x =>  x.User.FirstOrDefault().Active == true);
        }
    }
}
