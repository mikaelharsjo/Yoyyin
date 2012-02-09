using System;
using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Services;

namespace Yoyyin.Domain.Extensions
{
    public static class QuestionExtensions
    {
        public static IList<Answer> GetAnswers(this Question question)
        {
            var questionsHelper = new QAService(new EntityQARepository(new YoyyinEntities1()));
            return questionsHelper.GetAnswersByQuestion(question.QuestionID);
        }

        public static int GetNumberOfAnswers(this Question question)
        {
            var questionsHelper = new QAService(new EntityQARepository(new YoyyinEntities1()));
            return questionsHelper.GetNumberOfAnswersByQuestion(question.QuestionID);
        }

        public static bool DeleteAllowed(this Question question, Guid userId)
        {
            var questionsHelper = new QAService(new EntityQARepository(new YoyyinEntities1()))
            return questionsHelper.DeleteAllowed(question, userId);
        }
    }
}
