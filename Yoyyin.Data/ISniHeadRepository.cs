using System.Linq;

namespace Yoyyin.Data
{
    public interface ISniHeadRepository : IRepository<ISniHead>
    {
        IQueryable<ISniHead> Find();
        IQueryable<ISniHead> GetAllSniIncludingUsers();
    }
}