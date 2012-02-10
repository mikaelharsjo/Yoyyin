using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoyyin.Domain;

namespace Yoyyin.Web.Configuration
{
    public class CurrentUser : ICurrentUser
    {
        public Guid UserId
        {
            get { return Current.UserID; }
            set { throw new NotImplementedException(); }
        }
    }
}