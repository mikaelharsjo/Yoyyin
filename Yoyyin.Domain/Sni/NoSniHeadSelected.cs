using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;

namespace Yoyyin.Domain.Sni
{
    public class NoSniHeadSelected : ISniHead
    {
        public string Title
        {
            get { return "Ingen bransch vald"; }
            set { throw new System.NotImplementedException(); }
        }

        public ICollection<SniItem> SniItem
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public string SniHeadID
        {
            get { return string.Empty; }
            set { throw new System.NotImplementedException(); }
        }

        public ICollection<User> User
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }
}