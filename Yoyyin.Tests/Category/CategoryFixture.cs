using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;
using Answer = Yoyyin.Domain.Answer;
using Question = Yoyyin.Domain.Question;

namespace Yoyyin.Tests.Category
{
    [TestFixture]
    public class CategoryShould
    {
        private ICategory _category;
        [Test]
        public void HaveTitleAccordingToType()
        {
             _category = new BusinessIdeasCategory(new TestQAService());
            Assert.That(_category.Title, Is.EqualTo("Affärsidéer"));
        }

        [Test]
        public void HaveDescriptionAccordintToType()
        {
            _category = new FriendlyCategory(new TestQAService());
            Assert.That(_category.Description, Is.EqualTo("Här behöver inte affärsidéen vara hundra genomtänkt. Feedbacken ska vara positiv. Försök gärna förbättra affärsidéerna men säg inte att dom är dåliga."));
        }

        [Test]
        public void HaveIdAccordingToType()
        {
            _category = new MiscCategory(new TestQAService());
            Assert.That(_category.CategoryId, Is.EqualTo(2));
        }

        [Test]
        public void HaveAQuestionInCategoryBusinessIdeas()
        {
            _category = new BusinessIdeasCategory(new TestQAService());
            Assert.That(_category.GetLatestQuestion().Title, Is.EqualTo("senaste frågan"));
        }

        [Test]
        public void Have2QuestionsInBusinessIdeas()
        {
            _category = new BusinessIdeasCategory(new TestQAService());
            Assert.That(_category.GetQuestions().Count(), Is.EqualTo(2));
        }
    }

    public class TestQAService : IQAService
    {
        private IQARepository _repository;
        private QAService _inner;

        public TestQAService()
        {
            _repository = new TestQARepository();
            // for keeping it, DRY, no need for extra CreateQuestion in Test for example
            _inner = new QAService();
        }

        public Question CreateQuestion(Data.Question questionData)
        {
            return _inner.CreateQuestion(questionData);
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
            return _repository.GetQuestionsByCategory(category.CategoryId).Select(CreateQuestion);
        }

        public IList<Question> GetQuestionsByUser(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Question GetLatestQuestionByCategory(ICategory category)
        {
            return CreateQuestion(_repository.GetLatestQuestionByCategory(category.CategoryId));
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
