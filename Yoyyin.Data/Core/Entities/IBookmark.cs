using System;

namespace Yoyyin.Data.Core.Entities
{
    public interface IBookmark
    {
        System.Guid UserId { get; set; }
        System.Guid BookmarkedUserID { get; set; }
        Nullable<System.DateTime> Created { get; set; }
        IUser User { get; set; }
    }
}