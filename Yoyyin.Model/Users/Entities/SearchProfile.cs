using System.Collections.Generic;
using System.Linq;

namespace Yoyyin.Model.Users.Entities
{
    public class SearchProfile
    {
        public IEnumerable<string> SearchWords { get; set; }
        public IEnumerable<string> CompetencesNeeded { get; set; }
        public UserTypesNeeded UserTypesNeeded { get; set; }

        public bool ContainsString(string term)
        {
            return SearchWords.Any(s => s.ToLower().Contains(term)) || CompetencesNeeded.Any(s => s.ToLower().Contains(term));
        }
    }
}