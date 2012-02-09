namespace Yoyyin.Domain
{
    public class SniHead
    {
        public string Title { get; set; }

        public SniItem SniItem { get; set; }

        public int SniHeadID { get; set; }

        public object User
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }

    public class SniHeadWithUser
    {
        public IUser User { get; set; }
        public SniHead SniHead { get; set; }

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