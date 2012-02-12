using System;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web
{
    public partial class QuestionPage : System.Web.UI.Page
    {
        private IQAService _qaService;
        private Question _question;
        private ICategory _categoryType;
        public int QuestionID;
        public const int MaxQuestionLength = 110;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Int32.TryParse(Request["QuestionID"], out QuestionID);
            
            if (QuestionID <= 0) return;

            _question = _qaService.GetQuestion(QuestionID);
            _categoryType = _question.Category;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lnkCategory.InnerText = _categoryType.Title;
            lnkCategory.Attributes["href"] = "Category.aspx?Category=" + _categoryType.CategoryId;
            litBreadCrumb.Text = _question.Text.Truncate(MaxQuestionLength);

            btnAnswerDialog.Visible = WebHelpers.IsLoggedIn();
            divAnswerWhenLoggedIn.Visible = WebHelpers.IsLoggedIn();
            divAnswerWhenNotLoggedIn.Visible = !WebHelpers.IsLoggedIn();
        }
    }
}