using System;
using System.Collections.Generic;
using Yoyyin.Model.Users.Entities;

namespace Yoyyin.Model.Users.AggregateRoots
{
    public class Question : IQuestion
    {
        public Question()
        {
            Answers = new List<Answer>();    
        }

        public int QuestionId { get; set; }

        public Guid UserId { get; set; }

        public int Category { get; set; }

        public DateTime Created { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public IList<Answer> Answers { get; set; }
    }
}