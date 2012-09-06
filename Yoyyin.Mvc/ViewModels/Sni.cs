using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Mvc.Models
{
    public class SniHead
    {
        public string Title { get; set; }
        public string UrlToIdeas { get; set; }
        public string UrlToItems { get; set; }
    }

    public class SniItem
    {
        public string Title { get; set; }
        public string UrlToIdeas { get; set; }
        public string UrlToItems { get; set; }
    }

    public class SniConverter
    {
        public SniHead ConvertToVewModel(Model.Users.ValueObjects.SniHead head)
        {
            return new SniHead
                       {
                           Title = head.Title,
                           UrlToIdeas = string.Format("/Idea/ListBySniHead/{0}", head.SniHeadId),
                           UrlToItems = string.Format("/Sni/ListItems/{0}", head.SniHeadId)
                       };
        }

        public SniItem ConvertToVewModel(Model.Users.ValueObjects.SniItem item)
        {
            return new SniItem
            {
                Title = item.Title,
                UrlToIdeas = string.Format("/User/ListBySniNo/{0}", item.SniNo),
                UrlToItems = string.Format("/Sni/ListItems/{0}", item.SniNo)
            };
        }
    }
}