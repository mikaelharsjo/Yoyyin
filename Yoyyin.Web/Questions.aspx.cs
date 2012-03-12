using System;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web
{
    public partial class Questions : System.Web.UI.Page
    {
        public CategoryFactory CategoryFactory { get; set; }
        public IQAService QAService { get; set; }

        private const int CharsInQuestion = 100;
        const string Lastmessage = "<a href='Question.aspx?QuestionID={3}'>{0}</a><a href='Question.aspx?QuestionID={3}'><br /><strong>{1}</strong></a> av {2}";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebHelpers.IsLoggedIn())
            {
                btn1.Visible = false;
                btn2.Visible = false;
                btn3.Visible = false;
            }

            litLastQuestionIdea.Text = FormatQuestionTeaser(CategoryFactory.CreateCategory(CategoryType.BusinessIdeas, QAService).GetLatestQuestion());
            litLastQuestionFriendly.Text = FormatQuestionTeaser(CategoryFactory.CreateCategory(CategoryType.Friendly, QAService).GetLatestQuestion());
            litLastQuestionBusiness.Text = FormatQuestionTeaser(CategoryFactory.CreateCategory(CategoryType.BusinessIdeas, QAService).GetLatestQuestion());
        }

        private static string FormatQuestionTeaser(Question question)
        {
            if (question == null)
                return "";

            return string.Format(Lastmessage, question.Text.Truncate(CharsInQuestion),
                                 question.Created.ToFormattedString(),
                                 question.Owner .GetDisplayName(),
                                 question.QuestionId);
        }
    }
}