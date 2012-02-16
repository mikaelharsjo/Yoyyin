using Yoyyin.Domain.Users;

namespace Yoyyin.Domain.Sni
{
    public class SniHeadWithUser
    {
        public IUser User { get; set; }
        public ISniHead SniHead { get; set; }

        public SniItem SniItem
        {
            get { return SniHead.SniItem; }
        }

        public int SniHeadID
        {
            get { return SniItem.SniItemId; }
            set { SniItem.SniItemId = value; }
        }

        public string Title
        {
            get { return SniItem.Title; }
            set { SniItem.Title = value; }
        }
    }
}