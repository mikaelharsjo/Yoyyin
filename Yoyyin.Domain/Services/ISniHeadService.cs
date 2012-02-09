using System.Collections.Generic;

namespace Yoyyin.Domain.Services
{
    public interface ISniHeadService
    {
        IEnumerable<SniHead> GetAllSniHeadItems();
        IEnumerable<SniHeadWithUser> GetAllSniIncludingUsers();
        SniHead GetSniHead(string sniHeadId);
        IEnumerable<SniHead> GetAllSniHeads();
    }
}