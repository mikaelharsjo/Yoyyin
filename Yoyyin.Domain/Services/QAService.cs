using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.EntityFramework;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.QA;
using CategoryFactory = Yoyyin.Domain.Factories.CategoryFactory;
using CategoryType = Yoyyin.Domain.QA.CategoryType;

namespace Yoyyin.Domain.Services
{
    public class QAService : IQAService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        //// Poor mans Ioc Container
        //public QAService() : this(new EFQARepository(new YoyyinEntities1()), new UserService(new EntityUserRepository()), new CategoryFactory() ){
        //}

        // Dependency Injection enabled constructor
        public QAService(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public void CreateQuestionInDb(Question question)
        {
            throw new NotImplementedException();
            //_entityQaRepository.CreateQuestionInDb(question);
        }

        public void CreateAnswerInDb(Answer answer)
        {
            throw new NotImplementedException();
            //_entityQaRepository.CreateAnswerInDb(answer);
        }

        public IEnumerable<Question> GetQuestionsByCategory(ICategory category)
        {
            return _questionRepository
                .GetQuestionsByCategory(category.CategoryId);
        }

        public IList<Question> GetQuestionsByUser(Guid userID)
        {
            return _questionRepository
                                .GetQuestionsByUser(userID)
                                .ToList();
        }

        public Question GetLatestQuestionByCategory(ICategory category)
        {
            return _questionRepository.GetLatestQuestionByCategory(category.CategoryId);
        }

        public IEnumerable<Post> GetLatestPosts(int maxCount)
        {
            var latestQuestions = _questionRepository
                .FindAll()
                .OrderBy(q => q.Created);

            var latestAnswers = _answerRepository
                .FindAll()
                .OrderBy(a => a.Created);

            return MergeToPosts(latestQuestions, latestAnswers)
                .Take(maxCount);
        }

        //public IList<Answer> GetAnswersByUser(Guid userID)
        //{
        //    return _questionRepository
        //        .GetAnswersByUser(userID)
        //        .Select(_mapper.MapAnswer)
        //        .ToList();
        //}

        //public IEnumerable<Answer> GetAnswersByQuestion(int questionId)
        //{
        //    return _questionRepository
        //                .GetAnswersByQuestion(questionId)
        //                .Select(_mapper.MapAnswer)
        //                .ToList();
        //}

        //public int GetNumberOfAnswersByQuestion(int questionId)
        //{
        //    return _questionRepository.GetNumberOfAnswersByQuestion(questionId);
        //}

        public IEnumerable<Post> GetPostsByUser(Guid userId)
        {
            var questions = _questionRepository.GetQuestionsByUser(userId);
            var answers = _answerRepository.Find(a => a.UserId == userId);

            return MergeToPosts(questions, answers);
        }

        //public void DeleteQuestion(int questionId)
        //{
        //    _questionRepository.Delete(questionId);
        //}

        //public void DeleteAnswer(int answerId)
        //{
        //    _questionRepository.Delete(answerId);
        //}

        public bool DeleteAllowed(Question question, Guid userId)
        {
            bool notLoggedIn = userId == Guid.Empty;

            // logged In?
            bool deleteAllowed = !notLoggedIn && (userId == question.OwnerUserId);

            // owner?
            deleteAllowed = question.OwnerUserId == userId;

            return deleteAllowed;
        }

        //public Question GetQuestion(int questionID)
        //{
        //    return _mapper.MapQuestion(_questionRepository.GetQuestion(questionID));
        //}

        //public int GetNumberOfAnswers(int questionId)
        //{
        //    return _questionRepository.GetNumberOfAnswersByQuestion(questionId);
        //}

        /// <summary>
        /// Merges answers and questions into one list and returns sorted
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="answers"></param>
        /// <returns></returns>
        private static IEnumerable<Post> MergeToPosts(IEnumerable<Data.Question> questions, IEnumerable<Answer> answers)
        {
            var posts =
                answers.Select(
                    answer =>
                    new Post
                        {
                        //DisplayName = answer.User.GetDisplayName(),
                        Created = answer.Created,
                        Text = answer.Text,
                        UserId = answer.UserId,
                        QuestionId = answer.Question.QuestionID,
                        OwnerUserId = answer.Question.OwnerUserId
                    }).ToList();
            posts.AddRange(
                questions.Select(
                    question =>
                    new Post
                        {
                        //DisplayName = question.Owner.GetDisplayName(),
                        Created = question.Created,
                        Text = question.Text,
                        UserId = question.User.UserId,
                        QuestionId = question.QuestionID,
                        OwnerUserId = question.OwnerUserId
                    }));

            return (from x in posts orderby x.Created descending select x).ToList();
        }
    }
}

