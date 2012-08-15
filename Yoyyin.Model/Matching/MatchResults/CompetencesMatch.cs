using System.Collections.Generic;

namespace Yoyyin.Model.Matching.MatchResults
{
    public class CompetencesMatch : IMatchResult
    {
        private readonly IEnumerable<string> _neededCompetencesFlattened;
        private readonly IEnumerable<string> _competences;
        private bool _isMatch;

        //public CompetencesNeededMatch(bool isMatch)
        //{
        //    _isMatch = isMatch;
        //    _neededCompetencesFlattened = new string[0];
        //    _competences = new string[0];
        //}

        public CompetencesMatch(bool isMatch, IEnumerable<string> neededCompetencesFlattened, IEnumerable<string> competences)
        {
            _neededCompetencesFlattened = neededCompetencesFlattened;
            _competences = competences;
            _isMatch = isMatch;
        }

        public bool IsMatch
        {
            get { return _isMatch; }
        }

        public IEnumerable<string> Competences
        {
            get { return _competences; }
        }

        public IEnumerable<string> NeededCompetencesFlattened
        {
            get { return _neededCompetencesFlattened; }
        }
    }
}