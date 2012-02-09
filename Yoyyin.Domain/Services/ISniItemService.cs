using System.Collections.Generic;

namespace Yoyyin.Domain.Services
{
    public interface ISniItemService
    {
        IEnumerable<SniItem> GetSniItemsByHead(string sniHeadID);
    }
}