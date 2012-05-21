using System.Linq;
using Yoyyin.Data.Core.Entities;

namespace Yoyyin.Data.Core.Repositories
{
    public interface ISniHeadRepository : IRepository<SniHead>
    {
        //IQueryable<ISniHead> Find();
        IQueryable<ISniHead> GetAllSniIncludingUsers();
    }
}