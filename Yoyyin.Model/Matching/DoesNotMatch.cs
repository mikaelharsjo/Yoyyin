using Yoyyin.Model.Matching.MatchResults;

namespace Yoyyin.Model.Matching
{
    public class DoesNotMatch : IMatchResult
    {
        public bool IsMatch
        {
            get { return false; }
            set { ; }
        }
    }
}