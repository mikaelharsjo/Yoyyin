using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Data.Core.Repositories;
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

        //public IEnumerable<SniHeadWithUser> GetAllSniIncludingUsers()
        //{
        //    return _repository.GetAllSniIncludingUsers().Select(sniHead => new SniHeadWithUser { SniHead = sniHead, U})
        //}

        public ISniHead GetSniHead(string sniHeadId)
        {
            return sniHeadId != null
                       ? _repository.Find().First(x => x.SniHeadID == sniHeadId)
                       : new NoSniHeadSelected();
        }
    }
}
