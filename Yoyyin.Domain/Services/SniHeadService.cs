using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Mappers;

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

        public IEnumerable<SniHead> GetAllSniHeadItems()
        {
            return _repository.Find().Select(_sniHeadMapper.MapSniHead);
        }

        public IEnumerable<SniHeadWithUser> GetAllSniIncludingUsers()
        {
            return _repository.GetAllSniIncludingUsers().Select(_userMapper.MapSniHeadWithUser);
        }

        public SniHead GetSniHead(string sniHeadId)
        {
            var sniHeadData = _repository.Find().First(x => x.SniHeadID == sniHeadId);

            return _sniHeadMapper.MapSniHead(sniHeadData);
        }

        public IEnumerable<SniHead> GetAllSniHeads()
        {
            return _repository
                        .Find()
                        .Select(_sniHeadMapper.MapSniHead);
        }
    }
}
