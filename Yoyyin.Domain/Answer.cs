using System;

namespace Yoyyin.Domain
{
    public class Answer
    {
        public IUser User { get; set; }

        public string Text { get; set; }

        public Guid UserId { get; set; }

        public DateTime Created { get; set; }

        public int AnswerID { get; set; }

        public Question Question { get; set; }

        public int QuestionID { get; set; }

        public bool DeleteAllowed(Guid userId)
        {
            bool loggedIn = userId != Guid.Empty;

            // logged In?
            bool deleteAllowed = loggedIn && (userId == UserId);

            // owner of answer?
            deleteAllowed = UserId == userId;

            // owner of question?
            deleteAllowed = deleteAllowed || (Question.Owner.UserId == userId);

            return deleteAllowed;
        }
    }
}