using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Users.Entities
{
    public class Idea
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SniNo { get; set; }
        public string SniHeadId { get; set; }
        public SearchProfile SearchProfile { get; set; }
    }
}