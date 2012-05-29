using System.Collections.Generic;

namespace Yoyyin.Model.Users.Entities
{
    public class SearchProfile
    {
        public IEnumerable<string> SearchWords { get; set; }
        public IEnumerable<string> Competences { get; set; }
        public IEnumerable<string> CompetencesNeeded { get; set; }
        public UserTypesNeeded UserTypesNeeded { get; set; }
    }
}