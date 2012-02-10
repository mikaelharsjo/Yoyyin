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
}