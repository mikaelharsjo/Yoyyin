using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;

namespace Yoyyin.PresentationModel
{
    public class QuestionPresenter : IQuestionPresenter
    {
        private readonly IQAService _qaService;

        public QuestionPresenter(IQAService qaService)
        {
            _qaService = qaService;
        }

        public IPresentation Presentate(Question question)
        {
            return new QuestionPresentation
                       {
                           DisplayName = question.User != null ? question.User.GetDisplayName() : string.Empty,
                           UserId = question.User != null ? question.User.UserId : Guid.Empty,
                           Date = question.Created.ToFormattedString(),
                           Text = question.Text,
                           ShortText = question.Text.Truncate(100),
                           //NumberOfAnswers = _qaService.GetNumberOfAnswersByQuestion(question.QuestionId).ToString(),
                           QuestionId = question.QuestionID,
                           Title = question.Title
                       };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<Question> shouldBeConverted)
        {
            return shouldBeConverted.Select(Presentate);
        }
    }
}