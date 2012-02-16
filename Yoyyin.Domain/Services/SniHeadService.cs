using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Mappers;
using Yoyyin.Domain.Sni;

namespace Yoyyin.Domain.Services
{
    public class SniHeadService : ISniHeadService
    {
        private readonly ISniHeadRepository _repository;
        private readonly ISniHeadMapper _sniHeadMapper;
        private readonly IUserMapper _userMapper;

        public SniHeadService(ISniHeadRepository repository, ISniHeadMapper sniHeadMapper, IUserMapper userMapper)
        {
            _repository = repository;
            _sniHeadMapper = sniHeadMapper;
            _userMapper = userMapper;
        }

        public IEnumerable<ISniHead> GetAllSniHeadItems()
        {
            return _repository.Find().Select(_sniHeadMapper.MapSniHead);
        }

        public IEnumerable<SniHeadWithUser> GetAllSniIncludingUsers()
        {
            return _repository.GetAllSniIncludingUsers().Select(_userMapper.MapSniHeadWithUser);
        }

        public ISniHead GetSniHead(string sniHeadId)
        {
            return sniHeadId != null
                       ? _sniHeadMapper.MapSniHead(_repository.Find().First(x => x.SniHeadID == sniHeadId))
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
