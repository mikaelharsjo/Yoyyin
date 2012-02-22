using Yoyyin.Domain.Users;

namespace Yoyyin.PresentationModel
{
    public class CommentPresentation
    {
        public string Heading { get; set; }
        public string Text { get; set; }
        public string CellStyle { get; set; }
        public string CommentatorUrl { get; set; }
        public IUser User { get; set; }
        public string CommentatorDisplayName { get; set; }
        public string Created { get; set; }
        public int CommentId { get; set; }
        public bool DeleteVisible { get; set; }
        public IUser Commentator { get; set; }
    }
}