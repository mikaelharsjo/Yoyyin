using System.Collections.Generic;

namespace Yoyyin.Model.Matching
{
    public interface IMultipleMatcher
    {
        IEnumerable<Matcher> MatchAll();

        /// <summary>
        /// Returns matchers with at least one match, sorted by number of matches
        /// </summary>
        /// <returns></returns>
        IEnumerable<Matcher> GetSuccesFullMatches();

        MultipleMatcherStats GetStats();
    }
}