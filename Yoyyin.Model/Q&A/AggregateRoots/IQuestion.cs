using System;
using System.Collections.Generic;
using Yoyyin.Model.Users.Entities;

namespace Yoyyin.Model.Users.AggregateRoots
{
    public interface IQuestion
    {
        int QuestionId { get; set; }
        Guid UserId { get; set; }
        int Category { get; set; }
        DateTime Created { get; set; }
        string Text { get; set; }
        string Title { get; set; }
        IList<Answer> Answers { get; set; }
    }
}