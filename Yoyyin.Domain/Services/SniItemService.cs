using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public class SniItemService : ISniItemService
    {
        private readonly EntitySniItemRepository _repository;

        public SniItemService(EntitySniItemRepository repository)
        {
            _repository = repository;
        }

        private static SniItem CreateSniItem(Data.SniItem sniItem)
        {
            return new SniItem { Title = sniItem.Title };
        }

        public IEnumerable<SniItem> GetSniItemsByHead(string sniHeadID)
        {
            return _repository
                .Find()
                .Where(sniItem => sniItem.SniHeadID == sniHeadID)
                .Select(CreateSniItem);
        }
    }
}