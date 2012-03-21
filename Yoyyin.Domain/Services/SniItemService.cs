using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Services
{
    public class SniItemService : ISniItemService
    {
        private readonly SqlRepository<ISniItem> _repository;

        public SniItemService(SqlRepository<ISniItem> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ISniItem> GetSniItemsByHead(string sniHeadID)
        {
            return _repository
                .Find(sniItem => sniItem.SniHead.SniHeadID == sniHeadID);
        }
    }
}