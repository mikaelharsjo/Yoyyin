using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain
{
    public class Message
    {
        public DateTime Created { get; set; }
        public string Text { get; set; }
        public string FromMessage { get; set; }
        public User FromUser { get; set; }
        public User ToUser { get; set; }
        public int UserMessagesID { get; set; }
        public User User { get; set; }
    }
}
