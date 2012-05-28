using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Users.AggregateRoots
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
                    return "Jordbruk och jakt samt service i anslutning h�rtill";
                default:
                    return "hej";
            }
        }
    }
}