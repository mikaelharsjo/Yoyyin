using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
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
                           DisplayName = question.Owner != null ? question.Owner.GetDisplayName() : string.Empty,
                           UserId = question.Owner != null ? question.Owner.UserId : Guid.Empty,
                           Date = question.Created.ToFormattedString(),
                           Text = question.Text,
                           ShortText = question.Text.Truncate(100),
                           NumberOfAnswers = _qaService.GetNumberOfAnswersByQuestion(question.QuestionId).ToString(),
                           QuestionId = question.QuestionId,
                           Title = question.Title
                       };
        }

        public IEnumerable<IPresentation> Presentate(IEnumerable<Question> shouldBeConverted)
        {
            return shouldBeConverted.Select(Presentate);
        }
    }
}