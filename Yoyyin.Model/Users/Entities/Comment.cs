using System;
using System.Collections.Generic;

namespace Yoyyin.Model.Users.Entities
{
    public class Comment
    {
        public Guid UserId;
        //public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Comment> Comments { get; set; } 
    }
}