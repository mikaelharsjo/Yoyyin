using System;
using System.Collections.Generic;

namespace Yoyyin.Model.Users.Entities
{
    public class Comment
    {
        int UserId { get; set; }
        string Text { get; set; }
        DateTime Created { get; set; }
        IEnumerable<Comment> Comments { get; set; } 
    }
}