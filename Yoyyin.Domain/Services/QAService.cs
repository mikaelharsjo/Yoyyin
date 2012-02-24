using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Mappers;
using Yoyyin.Domain.QA;
using Answer = Yoyyin.Domain.QA.Answer;
using CategoryFactory = Yoyyin.Domain.QA.CategoryFactory;
using CategoryType = Yoyyin.Domain.QA.CategoryType;
using Question = Yoyyin.Domain.QA.Question;

namespace Yoyyin.Domain.Services
{
    public class QAService : IQAService
    {
        private readonly IQARepository _repository;
        private readonly IQAMapper _mapper;

        //// Poor mans Ioc Container
        //public QAService() : this(new EntityQARepository(new YoyyinEntities1()), new UserService(new EntityUserRepository()), new CategoryFactory() ){
        //}

        // Dependency Injection enabled constructor
        public QAService(IQARepository repository, IQAMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
                .Select(_mapper.MapQuestion)
                .ToList();
        }

        public IList<Question> GetQuestionsByUser(Guid userID)
        {
            return _repository
                                .GetQuestionsByUser(userID)
                                .Select(_mapper.MapQuestion)
                                .ToList();
        }

        public Question GetLatestQuestionByCategory(ICategory category)
        {
            return _mapper.MapQuestion(_repository
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
                .Select(_mapper.MapAnswer)
                .ToList();
        }

        public IEnumerable<Answer> GetAnswersByQuestion(int questionId)
        {
            return _repository
                        .GetAnswersByQuestion(questionId)
                        .Select(_mapper.MapAnswer)
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

            return MergeToPosts(questions.Select(_mapper.MapQuestion), answers.Select(_mapper.MapAnswer));
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
            var latestQuestions = _repository.GetLatestQuestions(maxPosts).Select(_mapper.MapQuestion);
            var latestAnswers = _repository.GetLatestAnswers(maxPosts).Select(_mapper.MapAnswer);

            return MergeToPosts(latestQuestions.AsEnumerable(), latestAnswers).Take(maxPosts);
        }

        public Question GetQuestion(int questionID)
        {
            return _mapper.MapQuestion(_repository.GetQuestion(questionID));
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
                    new Post
                        {
                        DisplayName = answer.User.GetDisplayName(),
                        Created = answer.Created,
                        Text = answer.Text,
                        UserId = answer.UserId,
                        QuestionId = answer.Question.QuestionId,
                        OwnerUserId = answer.Question.Owner.UserId
                    }).ToList();
            posts.AddRange(
                questions.Select(
                    question =>
                    new Post
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

