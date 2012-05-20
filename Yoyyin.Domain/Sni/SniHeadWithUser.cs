using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
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

        public ICollection<SniItem> SniItem
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public string SniHeadID
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        ICollection<User> ISniHead.User
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }
}