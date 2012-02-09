using System;

namespace Yoyyin.Domain
{
    public class Comment
    {
        public User User { get; set; }
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int? CommentCommentID { get; set; }

        public int CommentID { get; set; }
    }
}