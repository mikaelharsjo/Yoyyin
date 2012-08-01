using System;
using System.Linq;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Mvc.Services
{
    public class SniService
    {
        private readonly IUserRepository _repository;

        public SniService(IUserRepository repository)
        {
            _repository = repository;
        }

        public string GetTitle(string sniHeadId)
        {
            var sniHead = _repository.Query(m => m.SniHeads.FirstOrDefault(s => s.SniHeadId == sniHeadId));
            return sniHead != null ? sniHead.Title : string.Empty;
        }
    }
}