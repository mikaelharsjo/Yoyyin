using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;

using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Services
{
    public class SniHeadService : ISniHeadService
    {
        private readonly ISniHeadRepository _repository;

        public SniHeadService(ISniHeadRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ISniHead> GetAllSniHeadItems()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SniHeadWithUser> GetAllSniIncludingUsers()
        {
            return _repository.GetAllSniIncludingUsers();
        }

        public ISniHead GetSniHead(string sniHeadId)
        {
            return sniHeadId != null
                       ? _repository.Find().First(x => x.SniHeadID == sniHeadId)
                       : new NoSniHeadSelected();
        }

        public IEnumerable<ISniHead> GetAllSniHeads()
        {
            return _repository
                        .Find()
                        .Select(_sniHeadMapper.MapSniHead);
        }
    }
}
