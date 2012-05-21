using System;

namespace Yoyyin.Data.Core.Entities
{
    public interface IComment
    {
        System.Guid UserId { get; set; }
        System.Guid CommentUserId { get; set; }
        string Text { get; set; }
        System.DateTime Created { get; set; }
        int CommentID { get; set; }
        Nullable<int> CommentCommentID { get; set; }
        IUser User { get; set; }
        IUser User1 { get; set; }
    }
}