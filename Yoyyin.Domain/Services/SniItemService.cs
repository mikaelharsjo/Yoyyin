using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.EntityFramework;
using Yoyyin.Domain.Mappers;
using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Services
{
    public class SniItemService : ISniItemService
    {
        private readonly EFSniItemRepository _repository;
        private readonly ISniItemMapper _mapper;

        public SniItemService(EFSniItemRepository repository, ISniItemMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ISniItem> GetSniItemsByHead(string sniHeadID)
        {
            return _repository
                .Find(sniItem => sniItem.SniHeadID == sniHeadID)
                //.Where(sniItem => sniItem.SniHeadID == sniHeadID)
                .Select(_mapper.MapSniItem);
        }
    }
}