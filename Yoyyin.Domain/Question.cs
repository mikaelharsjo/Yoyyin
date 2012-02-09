using System;
using Yoyyin.Domain.Services;

namespace Yoyyin.Domain
{
    public class Question
    {
        public DateTime Created { get; set; }

        public ICategory Category { get; set; }

        //public Guid OwnerUserId { get; set; }

        public IUser Owner { get; set; }

        public string Text { get; set; }

        public int QuestionId { get; set; }

        public string Title { get; set; }
    }
}