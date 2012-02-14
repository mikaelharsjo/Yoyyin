using System.Collections.Generic;
using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Services
{
    public interface ISniHeadService
    {
        IEnumerable<ISniHead> GetAllSniHeadItems();
        IEnumerable<SniHeadWithUser> GetAllSniIncludingUsers();
        ISniHead GetSniHead(string sniHeadId);
        IEnumerable<ISniHead> GetAllSniHeads();
    }
}