namespace Yoyyin.Domain.Sni
{
    public class NoSniItemSelected : ISniItem
    {
        public string Title
        {
            get { return "Ingen underbransch vald"; }
            set { throw new System.NotImplementedException(); }
        }

        public int SniItemId
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }
}