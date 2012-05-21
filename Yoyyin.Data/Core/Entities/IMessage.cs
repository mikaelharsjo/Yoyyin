using System;

namespace Yoyyin.Data.Core.Entities
{
    public interface IMessage
    {
        System.Guid FromUserId { get; set; }
        System.Guid ToUserId { get; set; }
        string FromMessage { get; set; }
        Nullable<System.DateTime> Created { get; set; }
        string Subject { get; set; }
        int MessageID { get; set; }
        IUser User { get; set; }
        IUser User1 { get; set; }
    }
}