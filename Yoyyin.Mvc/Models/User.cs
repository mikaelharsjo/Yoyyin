using System;
using System.Collections.Generic;

namespace Yoyyin.Mvc.Models
{
    public class User
    {
        public IEnumerable<Idea> Ideas;
        public string DisplayName { get; set; }
        public string SmallProfileImageSrc { get; set; }
        public string City { get; set; }
        public string UserType { get; set; }
        public IEnumerable<string> UserTypesNeeded { get; set; } 
        public IEnumerable<string> Competences { get; set; }
        public IEnumerable<string> CompetencesNeeded { get; set; }

        public Guid id { get; set; }
    }
}