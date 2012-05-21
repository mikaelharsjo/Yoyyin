namespace Yoyyin.Data.Core.Entities
{
    public interface IAnswer
    {
        int AnswerID { get; set; }
        System.DateTime Created { get; set; }
        string Text { get; set; }
        IQuestion Question { get; set; }
        IUser User { get; set; }
        int QuestionID { get; set; }
    }
}
