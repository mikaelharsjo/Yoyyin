using System.Collections.Generic;

namespace Yoyyin.Model.Matching.MatchResult
{
    public class UserTypeMatch : IsMatchResult
    {
        private readonly int _userType;
        private readonly IEnumerable<int> _secondUserTypes;

        public UserTypeMatch(int userType, IEnumerable<int> secondUserTypes)
        {
            _userType = userType;
            _secondUserTypes = secondUserTypes;
        }

        public IEnumerable<int> SecondUserTypes
        {
            get { return _secondUserTypes; }
        }

        public int UserType
        {
            get { return _userType; }
        }
    }
}