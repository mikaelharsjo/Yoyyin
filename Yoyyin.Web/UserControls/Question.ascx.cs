using System;
using System.Collections.Generic;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;
using Yoyyin.PresentationModel;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web.UserControls
{
    public partial class QuestionControl : System.Web.UI.UserControl
    {
        public int QuestionId { get; set; }
        private Question _question;
        public IQAService QAService;
        public IQuestionPresenter QuestionPresenter { get; set; }
        public IAnswerPresenter AnswerConverter { get; set; }
        public ICurrentUser CurrentUser { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _question = QAService.GetQuestion(QuestionId);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            litQuestion.Text = _question.Text;
            imageQuestion.UserID = _question.Owner.UserId;
            deleteLinkQuestion.Visible = QAService.DeleteAllowed(_question, Current.UserID);

            var questionView = (QuestionPresentation)QuestionPresenter.Presentate((IEnumerable<Question>) _question);
            litOwner.Text = WebHelpers.FormatHeading(questionView.DisplayName, questionView.Date);
            
            lstAnswers.DataSource = AnswerConverter.Presentate(QAService.GetAnswersByQuestion(_question.QuestionId));
            lstAnswers.DataBind();
        }
    }
}