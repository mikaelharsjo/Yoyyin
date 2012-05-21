using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Yoyyin.Data.Core;

namespace Yoyyin.Data.Core.Entities
{
    public interface IVisit
    {
        System.Guid UserId { get; set; }
        Nullable<System.Guid> VisitingUserId { get; set; }
        System.DateTime Created { get; set; }
        int UserVisitID { get; set; }
        IUser User { get; set; }
        IUser User1 { get; set; }
    }
}