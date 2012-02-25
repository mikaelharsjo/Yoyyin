using System;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain
{
    public class Comment
    {
        public Comment()
        {
            User = new NullUser();
            Commentator = new NullUser();
        }

        public IUser User { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public int? CommentCommentID { get; set; }
        public int CommentID { get; set; }
        public IUser Commentator { get; set; }
    }
}