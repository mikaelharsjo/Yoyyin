using System.Collections.Generic;

namespace Yoyyin.Model.Matching.MatchResult
{
    public class UserTypeMatch : IMatchResult
    {
        private readonly int _userType;
        private readonly IEnumerable<int> _secondUserTypes;
        private bool _isMatch;

        public UserTypeMatch(bool isMatch, int userType, IEnumerable<int> secondUserTypes)
        {
            _userType = userType;
            _secondUserTypes = secondUserTypes;
            _isMatch = isMatch;
        }

        public bool IsMatch
        {
            get { return _isMatch; }
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