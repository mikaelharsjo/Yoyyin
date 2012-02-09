using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public class SniHeadService : ISniHeadService
    {
        private readonly IUserService _userService;
        private readonly ISniHeadRepository _repository;

        public SniHeadService(ISniHeadRepository repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        private SniHead CreateSniHead(Data.SniHead sniHeadData)
        {
            return new SniHead { Title = sniHeadData.Title };
        }

        private SniHeadWithUser CreateSniHeadWithUser(Data.SniHead sniHeadData)
        {
            return new SniHeadWithUser { SniHead = CreateSniHead(sniHeadData), User = _userService.CreateUser(sniHeadData.User.First()) };
        }



        public IEnumerable<SniHead> GetAllSniHeadItems()
        {
            return _repository.Find().Select(CreateSniHead);
        }

        public IEnumerable<SniHeadWithUser> GetAllSniIncludingUsers()
        {
            return _repository.GetAllSniIncludingUsers().Select(CreateSniHeadWithUser);
        }

        public SniHead GetSniHead(string sniHeadId)
        {
            var sniHeadData = _repository.Find().First(x => x.SniHeadID == sniHeadId);

            return CreateSniHead(sniHeadData);
        }

        public IEnumerable<SniHead> GetAllSniHeads()
        {
            return _repository
                        .Find()
                        .Select(CreateSniHead);
        }
    }
}
