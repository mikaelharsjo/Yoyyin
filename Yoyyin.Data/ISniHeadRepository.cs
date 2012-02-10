using System.Linq;

namespace Yoyyin.Data
{
    public interface ISniHeadRepository
    {
        IQueryable<SniHead> Find();
        IQueryable<SniHead> GetAllSniIncludingUsers();
    }
}