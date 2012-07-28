using System;

namespace Yoyyin.Model.Users.AggregateRoots
{
    public class Message
    {
        //System.Guid FromUserId { get; set; }
        //System.Guid ToUserId { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public string Subject { get; set; }
    }
}
