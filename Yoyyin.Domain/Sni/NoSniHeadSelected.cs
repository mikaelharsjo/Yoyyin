namespace Yoyyin.Domain.Sni
{
    public class NoSniHeadSelected : ISniHead
    {
        public string Title
        {
            get { return "Ingen bransch vald"; }
            set { throw new System.NotImplementedException(); }
        }

        public SniItem SniItem
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public int SniHeadID
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public object User
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }
}