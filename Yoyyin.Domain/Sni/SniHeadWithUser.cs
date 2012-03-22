using Yoyyin.Data;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain.Sni
{
    public class SniHeadWithUser : ISniHead
    {
        public IUser User { get; set; }
        public ISniHead SniHead { get; set; }

        public string Title
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public string SniHeadID
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }
}