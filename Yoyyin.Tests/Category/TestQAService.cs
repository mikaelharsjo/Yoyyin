using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Mappers;
using Yoyyin.Domain.QA;
using Yoyyin.Domain.Services;
using Yoyyin.Tests.Repositories;
using Yoyyin.Tests.Services;
using Answer = Yoyyin.Domain.QA.Answer;
using Question = Yoyyin.Domain.QA.Question;

namespace Yoyyin.Tests.Category
{
    public class TestQAService : IQAService
    {
        private IQARepository _repository;
        private QAService _inner;
        private IQAMapper _qaMapper;

        public TestQAService(IQAMapper qaMapper)
        {
            _qaMapper = qaMapper;
            _repository = new TestQARepository();
            // for keeping it, DRY, no need for extra CreateQuestion in Test for example
            _inner = new QAService(new TestQARepository(),
                                   new QAMapper(new UserMapper(new SniHeadMapper(), new SniItemMapper())));
        }

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
            return _repository.GetQuestionsByCategory(category.CategoryId).Select(_qaMapper.MapQuestion);
        }

        public IList<Question> GetQuestionsByUser(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Question GetLatestQuestionByCategory(ICategory category)
        {
            return _qaMapper.MapQuestion(_repository.GetLatestQuestionByCategory(category.CategoryId));
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