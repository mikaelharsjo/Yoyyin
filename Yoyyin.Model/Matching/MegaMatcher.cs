using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yoyyin.Model.Matching.MatchResults;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Matching
{
    public class MegaMatcher
    {
        private readonly IUser _user;
        private IUserRepository _repository;

        public MegaMatcher(IUser user, IUserRepository repository)
        {
            _user = user;
            _repository = repository;
        }

        public IEnumerable<MegaMatchResult> Match()
        {
            return _repository
                .Query(m => m.Users)
                .Select(u => new MegaMatchResult {MatchResult = new Matcher(_user, u, _repository).Match(), User = u});
        }
    }
}
