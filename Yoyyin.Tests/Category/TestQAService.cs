using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;

namespace Yoyyin.Tests.Category
{
    public class TestQAService : IQAService
    {
        private IQuestionRepository _repository;
        private QAService _inner;

        public void CreateQuestionInDb(Question question)
        {
            throw new NotImplementedException();
        }

        public void CreateAnswerInDb(Answer answer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestionsByCategory(ICategory category)
        {
            return _repository.GetQuestionsByCategory(category.CategoryId);
        }

        public IList<Question> GetQuestionsByUser(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Question GetLatestQuestionByCategory(ICategory category)
        {
            return _repository.GetLatestQuestionByCategory(category.CategoryId);
        }

        public IList<Answer> GetAnswersByUser(Guid userID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAnswersByQuestion(int questionId)
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

        public bool DeleteAllowed(Question question, Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetLatestPosts(int maxPosts)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(int questionID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}