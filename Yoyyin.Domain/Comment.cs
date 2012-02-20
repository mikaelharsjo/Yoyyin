using System;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain
{
    public class Comment
    {
        public IUser User { get; set; }
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int? CommentCommentID { get; set; }

        public int CommentID { get; set; }
    }
}