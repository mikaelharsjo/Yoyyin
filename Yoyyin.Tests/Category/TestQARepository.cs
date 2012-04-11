using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Yoyyin.Data;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain.QA;

namespace Yoyyin.Tests.Category
{
    public class TestQuestionRepository : IQuestionRepository
    {
        private readonly List<Data.Question> _questions;

        public TestQuestionRepository()
        {
            _questions = new List<Data.Question>
                             {
                                 new Data.Question {Title = "första frågan", Created = new DateTime(1900, 12, 31)},
                                 new Data.Question {Title = "senaste frågan", Created = new DateTime(2012, 2, 7), Category = (int)CategoryType.BusinessIdeas}
                             };
        }


        public void Add(Question entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Question entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> Find(Expression<Func<Question, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> GetQuestionsByCategory(int category)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> GetQuestionsByUser(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Question GetLatestQuestionByCategory(int category)
        {
            throw new NotImplementedException();
        }
    }
}