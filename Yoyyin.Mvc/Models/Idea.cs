using System.Collections.Generic;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Mvc.Models
{
    public class Idea
    {
        public IEnumerable<string> UserTypesNeeded { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SniNo { get; set; }
        public string SniHeadId { get; set; }
        public Funding Funding { get; set; }
        public IEnumerable<string> CompetencesNeeded { get; set; }
        public string SniHeadTitle { get; set; }
        //public SearchProfile SearchProfile { get; set; }        
    }
}