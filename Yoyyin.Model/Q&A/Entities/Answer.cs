using System;

namespace Yoyyin.Model.Users.Entities
{
    public class Answer : IAnswer
    {
        //public virtual int AnswerID { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
    }
}
