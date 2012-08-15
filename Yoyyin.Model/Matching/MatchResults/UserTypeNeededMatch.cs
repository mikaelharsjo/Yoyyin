using System.Collections.Generic;

namespace Yoyyin.Model.Matching.MatchResults
{
    public class UserTypeNeededMatch : IsMatchResult
    {
        private readonly IEnumerable<int> _userTypesFlattened;
        private readonly int _userType;

        public UserTypeNeededMatch(IEnumerable<int> userTypesFlattened, int userType)
        {
            _userTypesFlattened = userTypesFlattened;
            _userType = userType;
        }

        public int UserType
        {
            get { return _userType; }
        }

        public IEnumerable<int> UserTypesFlattened
        {
            get { return _userTypesFlattened; }
        }
    }
}