namespace Yoyyin.Model.Users.Entities
{
    public class Idea
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SniHeadID { get; set; }
        public string SniNo { get; set; }
        public SearchProfile SearchProfile { get; set; }
    }
}