using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;

namespace Yoyyin.Domain.Sni
{
    public class NoSniItemSelected : ISniItem
    {
        public string Title
        {
            get { return "Ingen underbransch vald"; }
            set { throw new System.NotImplementedException(); }
        }

        public string SniNo
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