using Yoyyin.Data;

namespace Yoyyin.Domain.Sni
{
    public class NoSniHeadSelected : ISniHead
    {
        public string Title
        {
            get { return "Ingen bransch vald"; }
            set { throw new System.NotImplementedException(); }
        }

        public string SniHeadID
        {
            get { return string.Empty; }
            set { throw new System.NotImplementedException(); }
        }
    }
}