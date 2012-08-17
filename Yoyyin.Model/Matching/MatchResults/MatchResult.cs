namespace Yoyyin.Model.Matching.MatchResults
{
    public class MatchResult
    {
        public SniHeadMatch SniHeadMatch { get; set; }
        public CompetencesMatch Competences { get; set; }
        public UserTypeMatch UserType { get; set; }
        public UserTypeNeededMatch UserTypesNeeded { get; set; }
        public CompetencesMatch CompetencesNeeded { get; set; }
    }
}