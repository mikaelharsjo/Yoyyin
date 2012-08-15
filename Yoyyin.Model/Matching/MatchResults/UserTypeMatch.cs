using System.Collections.Generic;
using System.Linq;
using Yoyyin.Model.Users;

namespace Yoyyin.Model.Matching.MatchResults
{
    public class UserTypeMatch : IMatchResult
    {
        private readonly int _userType;
        private readonly IEnumerable<int> _secondUserTypes;
        private bool _isMatch;
        private IUserRepository _repository;

        public UserTypeMatch(bool isMatch, int userType, IEnumerable<int> secondUserTypes, IUserRepository repository)
        {
            _userType = userType;
            _secondUserTypes = secondUserTypes;
            _repository = repository;
            _isMatch = isMatch;
        }

        public bool IsMatch
        {
            get { return _isMatch; }
        }

        public IEnumerable<string> SecondUserTypes
        {
            get
            {
                return
                    _secondUserTypes.Select(id => _repository.Query(m => m.UserTypes.First(ut => ut.UserTypeId == id).Title));
            }
        }

        public string UserType
        {
            get { return _repository.Query(m => m.UserTypes.First(ut => ut.UserTypeId == _userType).Title); }
        }
    }
}