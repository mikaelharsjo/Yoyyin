using Yoyyin.Model.Matching.MatchResult;

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