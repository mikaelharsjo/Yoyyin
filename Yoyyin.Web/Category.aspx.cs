using System;
using System.Collections.Generic;
using System.Globalization;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;
using Yoyyin.PresentationModel;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web
{
    public partial class CategoryPage : System.Web.UI.Page
    {
        private ICategory _category;
        public const int MaxQuestionLength = 200;
        public IQAService QAService { get; set; }
        public IQuestionPresenter QuestionPresenter { get; set; }
        public CategoryFactory CategoryFactory { get; set; }

        protected override void OnInit(EventArgs e)
        {
            int categoryType;
            base.OnInit(e);
            Int32.TryParse(Request["Category"], out categoryType);

            _category = CategoryFactory.CreateCategory(categoryType, QAService);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lnkCategory.Text = _category.Description;
            
            lstQuestions.DataSource = QuestionPresenter.Presentate(_category.GetQuestions());
            lstQuestions.DataBind();
            btnQuestion.Visible = WebHelpers.IsLoggedIn();

            btnQuestion.Attributes.Add("data-category-id", _category.CategoryId.ToString(CultureInfo.InvariantCulture));
        }

        protected string GetDate(object dataItem)
        {
            var question = (Question) dataItem;
            return question.Created.ToFormattedString();
        }

        protected string GetNumberOfAnswers(object dataItem)
        {
            var question = (Question) dataItem;
            return QAService.GetNumberOfAnswersByQuestion(question.QuestionId).ToString(CultureInfo.InvariantCulture);
        }
    }
}