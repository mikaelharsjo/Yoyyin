using System;

namespace Yoyyin.Domain
{
    /// <summary>
    /// An abstraction (or view model) representing either an answer or an question
    /// </summary>
    public class Post
    {
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public Guid UserId { get; set; }
        public int QuestionId { get; set; }
        public Guid OwnerUserId { get; set; }
        public string DisplayName { get; set; }

        public string GetQuestionUrl()
        {
            throw new Exception("not implemented");
        }
    }
}
