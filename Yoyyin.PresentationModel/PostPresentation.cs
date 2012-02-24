using System;

namespace Yoyyin.PresentationModel
{
    public class PostPresentation : IPresentation
    {
        public string DisplayName { get; set; }
        public string Text { get; set; }
        public string ShortText { get; set; }
        public Guid UserId { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public string QuestionUrl { get; set; }
    }
}