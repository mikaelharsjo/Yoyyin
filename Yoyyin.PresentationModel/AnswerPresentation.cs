using System;

namespace Yoyyin.PresentationModel
{
    public class AnswerPresentation : IPresentation
    {
        public bool DeleteAllowed { get; set; }
        public string DisplayName { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public string Date { get; set; }
        public int AnswerId { get; set; }
    }
}