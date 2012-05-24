namespace Yoyyin.Model.Users.ValueObjects
{
    // Sni is a standard for categorizing businesses
    public class Sni
    {
        public SniItem SniItem { get; set; }
        public SniHead SniHead { get; set; }

        public Sni()
        {
        }

        public string ToString()
        {
            switch(SniItem.SniNo)
            {
                case "1":
                    return "Jordbruk och jakt samt service i anslutning härtill";
                default:
                    return "hej";
            }
        }
    }

    public class SniItem
    {
        public string SniNo { get; set; }
        public string Title { get; set; }
    }

    public class SniHead
    {
        public string SniHeadId { get; set; }
        public string Title { get; set; }
    }
}