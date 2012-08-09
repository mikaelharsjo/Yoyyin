using System.Collections.Generic;

namespace Yoyyin.Model.Matching.MatchResult
{
    public class CompetencesNeededMatch : IsMatchResult
    {
        private readonly IEnumerable<string> _neededCompetencesFlattened;
        private readonly IEnumerable<string> _competences;

        public CompetencesNeededMatch(IEnumerable<string> neededCompetencesFlattened, IEnumerable<string> competences)
        {
            _neededCompetencesFlattened = neededCompetencesFlattened;
            _competences = competences;
        }
    }
}