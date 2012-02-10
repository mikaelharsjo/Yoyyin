using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;

namespace Yoyyin.Tests.Category
{
    public class TestQARepository : IQARepository
    {
        private readonly List<Data.Question> _questions;

        public TestQARepository()
        {
            _questions = new List<Data.Question>
                             {
                                 new Data.Question {Title = "första frågan", Created = new DateTime(1900, 12, 31)},
                                 new Data.Question {Title = "senaste frågan", Created = new DateTime(2012, 2, 7), Category = (int)CategoryType.BusinessIdeas}
                             };
        }

        public void CreateQuestionInDb(Data.Question question)
        {
            throw new NotImplementedException();
        }

        public void CreateAnswerInDb(Data.Answer answer)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Data.Question> GetQuestionsByCategory(int category)
        {
            return _questions
                .Where(question => question.Category == category)
                .AsQueryable();
        }

        public IQueryable<Data.Question> GetQuestionsByUser(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Data.Question GetLatestQuestionByCategory(int category)
        {
            return _questions.Last();
        }

        public IQueryable<Data.Answer> GetAnswersByUser(Guid userID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Data.Answer> GetAnswersByQuestion(int questionId)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfAnswersByQuestion(int questionId)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(int questionId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnswer(int answerId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Data.Question> GetLatestQuestions(int maxCount)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Data.Answer> GetLatestAnswers(int maxCount)
        {
            throw new NotImplementedException();
        }

        public Data.Question GetQuestion(int questionID)
        {
            throw new NotImplementedException();
        }
    }
}