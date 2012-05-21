using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yoyyin.Data.Core.Entities
{
    public interface Iaspnet_Users
    {
        System.Guid ApplicationId { get; set; }
        System.Guid UserId { get; set; }
        string UserName { get; set; }
        string LoweredUserName { get; set; }
        string MobileAlias { get; set; }
        bool IsAnonymous { get; set; }
        System.DateTime LastActivityDate { get; set; }
        IUser User { get; set; }
    }
}
