namespace Yoyyin.Model.Matching.MatchResults
{
    public class MatchResult
    {
        public int GetScore()
        {
            int score = SniHeadMatch != null ? (SniHeadMatch.IsMatch ? 1 : 0) : 0;
            score += Competences != null ? (Competences.IsMatch ? 1 : 0) : 0;
            score += UserType != null ? (UserType.IsMatch ? 1 : 0) : 0;
            score += UserTypesNeeded != null ? (UserTypesNeeded.IsMatch ? 1 : 0) : 0;
            score += CompetencesNeeded != null ? (CompetencesNeeded.IsMatch ? 1 : 0) : 0;
            return score;
        }

        public int Score
        {
            get { return GetScore() * 20; }
        }

        public SniHeadMatch SniHeadMatch { get; set; }
        public CompetencesMatch Competences { get; set; }
        public UserTypeMatch UserType { get; set; }
        public UserTypeNeededMatch UserTypesNeeded { get; set; }
        public CompetencesMatch CompetencesNeeded { get; set; }
    }
}