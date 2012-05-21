using System.Collections.Generic;

namespace Yoyyin.Data.Core.Entities
{
    public interface IQuestion
    {
        int QuestionID { get; set; }
        System.Guid OwnerUserId { get; set; }
        int Category { get; set; }
        System.DateTime Created { get; set; }
        string Text { get; set; }
        string Title { get; set; }
        ICollection<Answer> Answer { get; set; }
        IUser User { get; set; }
    }
}