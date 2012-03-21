using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Services
{
    public interface ISniItemService
    {
        IEnumerable<ISniItem> GetSniItemsByHead(string sniHeadID);
    }
}