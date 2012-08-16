using System.Collections.Generic;
using Yoyyin.Model.Users;
using System.Linq;

namespace Yoyyin.Model.Matching.MatchResults
{
    public class UserTypeNeededMatch : IMatchResult
    {
        private readonly IEnumerable<int> _userTypesFlattened;
        private readonly int _userType;
        private IUserRepository _repository;
        private bool _isMatch;

        public UserTypeNeededMatch(bool isMatch, IEnumerable<int> userTypesFlattened, int userType, IUserRepository repository)
        {
            _userTypesFlattened = userTypesFlattened;
            _userType = userType;
            _repository = repository;
            _isMatch = isMatch;
        }

        public bool IsMatch
        {
            get { return _isMatch; }
        }

        public string UserType
        {
            get
            {
                return _repository
                    .Query(m => m.UserTypes)
                    .First(ut => ut.UserTypeId == _userType)
                    .Title;
            }
        }

        public IEnumerable<string> UserTypesFlattened
        {
            get
            {
                return
                    _userTypesFlattened.Select(
                        ut => _repository
                                .Query(m => m.UserTypes)
                                .First(u => u.UserTypeId == ut)
                                .Title);
            }
        }
    }
}