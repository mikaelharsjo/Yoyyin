using System.Linq;

namespace Yoyyin.Data
{
    public interface ISniHeadRepository : IRepository<ISniHead>
    {
        IQueryable<SniHead> Find();
        IQueryable<SniHead> GetAllSniIncludingUsers();
    }
}