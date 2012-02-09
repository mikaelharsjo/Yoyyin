using System;

namespace Yoyyin.PresentationModel
{
    public class MessageView
    {
        public string DisplayName { get; set; }
        public string ToDisplayName { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public string MessageShort { get; set; }
        public int UserMessagesID { get; set; }
        public Guid FromUserId { get; set; }
    }

    public class CommentView
    {
        public string Heading { get; set; }
        public string Text { get; set; }
    }
}