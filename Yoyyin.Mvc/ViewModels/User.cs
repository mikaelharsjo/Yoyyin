using System;
using System.Collections.Generic;

namespace Yoyyin.Mvc.ViewModels
{
    public class User
    {
        public IEnumerable<Idea> Ideas;
        public string DisplayName { get; set; }
        public string ProfileImageSrc { get; set; }
        public string City { get; set; }
        public string UserType { get; set; }
        public IEnumerable<string> UserTypesNeeded { get; set; } 
        public IEnumerable<string> Competences { get; set; }
        public IEnumerable<string> CompetencesNeeded { get; set; }
        public LookingFor LookingFor { get; set; }
        public string DetailsHref { get; set; }
        public string Presentation { get; set; }

        public Guid id { get; set; }
    }
}