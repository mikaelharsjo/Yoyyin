namespace Yoyyin.Model.Users.Entities
{
    public class SniCategory : ICategory
    {
        public string CategoryId { get; set; }
        public string Title { get; set; }
        ICategory SubCategory { get; set; }
    }
}