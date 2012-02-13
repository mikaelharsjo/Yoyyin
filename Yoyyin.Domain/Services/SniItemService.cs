using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Mappers;

namespace Yoyyin.Domain.Services
{
    public class SniItemService : ISniItemService
    {
        private readonly EntitySniItemRepository _repository;
        private readonly ISniItemMapper _mapper;

        public SniItemService(EntitySniItemRepository repository, ISniItemMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<SniItem> GetSniItemsByHead(string sniHeadID)
        {
            return _repository
                .Find()
                .Where(sniItem => sniItem.SniHeadID == sniHeadID)
                .Select(_mapper.MapSniItem);
        }
    }
}