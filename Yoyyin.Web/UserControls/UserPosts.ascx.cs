using System;
using Yoyyin.Domain.Services;
using Yoyyin.PresentationModel;

namespace Yoyyin.Web.UserControls
{
    public partial class UserPosts : System.Web.UI.UserControl
    {
        public Guid UserId { get; set; }
        protected const int MaxQuestionLength = 120;
        public IQAService QaService { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserId == Guid.Empty) return;
            
            var questions = QaService.GetPostsByUser(UserId);
            var postConverter = new PostPresenter();
            lstQuestions.DataSource = postConverter.Presentate(questions);
            lstQuestions.DataBind();
        }
    }
}