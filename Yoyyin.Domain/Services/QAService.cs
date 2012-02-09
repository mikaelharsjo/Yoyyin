using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public class QAService : IQAService
    {
        private readonly IQARepository _repository;
        private readonly IUserService _userService;
        private readonly CategoryFactory _categoryFactory;

        // Poor mans Ioc Container
        public QAService() : this(new EntityQARepository(new YoyyinEntities1()), new UserService(new EntityUserRepository()), new CategoryFactory() ){
        }

        // Dependency Injection enabled constructor
        public QAService(IQARepository repository, IUserService userService, CategoryFactory categoryFactory)
        {
            _repository = repository;
            _userService = userService;
            _categoryFactory = categoryFactory;
        }

        public Question CreateQuestion(Data.Question questionData)
        {
            return new Question
                       {
                           Created = questionData.Created,
                           Category = _categoryFactory.CreateCategory((CategoryType)questionData.Category, this),
                           Owner = _userService.CreateUser(questionData.User),
                           Text = questionData.Text,
                           Title = questionData.Title
                       };
        }

        private Answer CreateAnswer(Data.Answer answerData)
        {
            return new Answer
                       {
                           AnswerID = answerData.AnswerID,
                           Created = answerData.Created,
                           Question = CreateQuestion(answerData.Question),
                           Text = answerData.Text,
                           User = _userService.CreateUser(answerData.User)
                       };
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
            return _repository
                            .GetQuestionsByCategory(category.CategoryId)
                            .Select(CreateQuestion)
                            .ToList();
        }

        public IList<Question> GetQuestionsByUser(Guid userID)
        {
            return _repository
                                .GetQuestionsByUser(userID)
                                .Select(CreateQuestion)
                                .ToList();
        }

        public Question GetLatestQuestionByCategory(ICategory category)
        {
            return CreateQuestion(_repository
                                      .GetLatestQuestionByCategory(category.CategoryId));
        }

        //public IEnumerable<Post> GetLatestPosts(int maxCount)
        //{
        //    var latestQuestions = (from x in Entities.Question orderby x.Created select x);
        //    var latestAnswers = (from x in Entities.Answer orderby x.Created select x);

        //    return MergeToPosts(latestQuestions, latestAnswers).Take(maxCount);
        //}

        public IList<Answer> GetAnswersByUser(Guid userID)
        {
            return _repository
                .GetAnswersByUser(userID)
                .Select(CreateAnswer)
                .ToList();
        }

        public IEnumerable<Answer> GetAnswersByQuestion(int questionId)
        {
            return _repository
                        .GetAnswersByQuestion(questionId)
                        .Select(CreateAnswer)
                        .ToList();
        }

        public int GetNumberOfAnswersByQuestion(int questionId)
        {
            return _repository.GetNumberOfAnswersByQuestion(questionId);
        }

        public IEnumerable<Post> GetPostsByUser(Guid userId)
        {
            var questions = _repository.GetQuestionsByUser(userId);
            var answers = _repository.GetAnswersByUser(userId);

            return MergeToPosts(questions.Select(CreateQuestion), answers.Select(CreateAnswer));
        }

        ///// <summary>
        ///// Merges answers and questions into one list and returns sorted
        ///// </summary>
        ///// <param name="questions"></param>
        ///// <param name="answers"></param>
        ///// <returns></returns>
        //private static IEnumerable<Post> MergeToPosts(IEnumerable<Question> questions, IEnumerable<Answer> answers)
        //{
        //    var posts =
        //        answers.Select(
        //            answer =>
        //            new Post()
        //            {
        //                DisplayName = answer.User.GetDisplayName(),
        //                Created = answer.Created,
        //                Text = answer.Text,
        //                UserId = answer.UserId,
        //                QuestionId = answer.QuestionID,
        //                OwnerUserId = answer.Question.OwnerUserId
        //            }).ToList();
        //    posts.AddRange(
        //        questions.Select(
        //            question =>
        //            new Post()
        //            {
        //                DisplayName = question.User.GetDisplayName(),
        //                Created = question.Created,
        //                Text = question.Text,
        //                UserId = question.OwnerUserId,
        //                QuestionId = question.QuestionID,
        //                OwnerUserId = question.OwnerUserId
        //            }));

        //    return (from x in posts orderby x.Created descending select x).ToList();
        //}

        public void DeleteQuestion(int questionId)
        {
            _repository.DeleteQuestion(questionId);
        }

        public void DeleteAnswer(int answerId)
        {
            _repository.DeleteAnswer(answerId);
        }

        public bool DeleteAllowed(Question question, Guid userId)
        {
            bool notLoggedIn = userId == Guid.Empty;

            // logged In?
            bool deleteAllowed = !notLoggedIn && (userId == question.Owner.UserId);

            // owner?
            deleteAllowed = question.Owner.UserId == userId;

            return deleteAllowed;
        }

        public IEnumerable<Post> GetLatestPosts(int maxPosts)
        {
            var latestQuestions = _repository.GetLatestQuestions(maxPosts).Select(CreateQuestion);
            var latestAnswers = _repository.GetLatestAnswers(maxPosts).Select(CreateAnswer);

            return MergeToPosts(latestQuestions.AsEnumerable(), latestAnswers).Take(maxPosts);
        }

        public Question GetQuestion(int questionID)
        {
            return CreateQuestion(_repository.GetQuestion(questionID));
        }

        public int GetNumberOfAnswers(int questionId)
        {
            return _repository.GetNumberOfAnswersByQuestion(questionId);
        }

        /// <summary>
        /// Merges answers and questions into one list and returns sorted
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="answers"></param>
        /// <returns></returns>
        private static IEnumerable<Post> MergeToPosts(IEnumerable<Question> questions, IEnumerable<Answer> answers)
        {
            var posts =
                answers.Select(
                    answer =>
                    new Post()
                    {
                        DisplayName = answer.User.GetDisplayName(),
                        Created = answer.Created,
                        Text = answer.Text,
                        UserId = answer.UserId,
                        QuestionId = answer.QuestionID,
                        OwnerUserId = answer.Question.Owner.UserId
                    }).ToList();
            posts.AddRange(
                questions.Select(
                    question =>
                    new Post()
                    {
                        DisplayName = question.Owner.GetDisplayName(),
                        Created = question.Created,
                        Text = question.Text,
                        UserId = question.Owner.UserId,
                        QuestionId = question.QuestionId,
                        OwnerUserId = question.Owner.UserId
                    }));

            return (from x in posts orderby x.Created descending select x).ToList();
        }
    }
}

