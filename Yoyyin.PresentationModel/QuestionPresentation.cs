using System;

namespace Yoyyin.PresentationModel
{
    public class QuestionPresentation : IPresentation
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ShortText { get; set; }
        public string DisplayName { get; set; }
        public Guid UserId { get; set; }
        public string Date { get; set; }
        public int QuestionId { get; set; }
        public string NumberOfAnswers { get; set; }
    }
}