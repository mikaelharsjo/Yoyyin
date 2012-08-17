using System.Linq;
using Yoyyin.Model.Users;

namespace Yoyyin.Model.Matching.MatchResults
{
    public class SniHeadMatch : IMatchResult
    {
        private bool _isMatch;
        private string _firstSniHead;
        private string _secondSniHead;
        private IUserRepository _repository;

        public SniHeadMatch(bool isMatch, string firstSniHead, string secondSniHead)
        {
            _isMatch = isMatch;
            _firstSniHead = firstSniHead;
            _secondSniHead = secondSniHead;
        }

        public SniHeadMatch(bool isMatch, string firstSniHead, string secondSniHead, IUserRepository repository)
        {
            _isMatch = isMatch;
            _firstSniHead = firstSniHead;
            _secondSniHead = secondSniHead;
            _repository = repository;
        }

        public bool IsMatch
        {
            get { return _isMatch; }
        }

        public string SecondSniHead
        {
            get
            {
                return _repository
                    .Query(m => m.SniHeads)
                    .First(s => s.SniHeadId == _secondSniHead)
                    .Title;
            }
        }

        public string FirstSniHead
        {
            get
            {
                return _repository
                    .Query(m => m.SniHeads)
                    .First(s => s.SniHeadId == _firstSniHead)
                    .Title;
            }
        }
    }
}