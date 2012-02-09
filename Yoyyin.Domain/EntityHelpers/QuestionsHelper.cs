using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain.Extensions;

namespace Yoyyin.Domain.EntityHelpers
{
    public class QuestionsHelper : EntityBase
    {
        public void CreateQuestionInDb(Question question)
        {
            using (var entities = new YoyyinEntities1())
            {
                entities.Question.AddObject(question);
                entities.SaveChanges();
            }
        }

        public void CreateAnswerInDb(Answer answer)
        {
            using (var entities = new YoyyinEntities1())
            {
                entities.Answer.AddObject(answer);
                entities.SaveChanges();
            }
        }

        public List<Question> GetQuestionsByCategory(Category category)
        {
            var questions = from x in Entities.Question.Include("User") where x.Category == (int)category orderby x.Created descending select x;
            return questions.ToList();
        }

        public List<Question> GetQuestionsByUser(Guid userID)
        {
            var questions = from x in Entities.Question where x.OwnerUserId == userID select x;
            return questions.ToList();
        }

        public Question GetLatestQuestionByCategory(int category)
        {
            return
                (from x in Entities.Question where x.Category == category orderby x.Created descending select x).FirstOrDefault();
        }

        public IEnumerable<Post> GetLatestPosts(int maxCount)
        {
            var latestQuestions = (from x in Entities.Question orderby x.Created select x);
            var latestAnswers = (from x in Entities.Answer orderby x.Created select x);

            return MergeToPosts(latestQuestions, latestAnswers).Take(maxCount);
        }

        public List<Answer> GetAnswersByUser(Guid userID)
        {
            var answers = from x in Entities.Answer where x.UserId == userID select x;
            return answers.ToList();
        }

        public List<Answer> GetAnswersByQuestion(int questionId)
        {
            var answers = from x in Entities.Answer.Include("User") where x.QuestionID == questionId select x;
            return answers.ToList();
        }

        public int GetNumberOfAnswersByQuestion(int questionId)
        {
            // optimixe with entity command?
            return (from x in Entities.Answer where x.QuestionID == questionId select x).Count();
        }

        public IEnumerable<Post> GetPostsByUser(Guid userId)
        {
            var questions = GetQuestionsByUser(userId);
            var answers = GetAnswersByUser(userId);

            return MergeToPosts(questions, answers);
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
                            OwnerUserId = answer.Question.OwnerUserId
                        }).ToList();
            posts.AddRange(
                questions.Select(
                    question =>
                    new Post()
                        {
                            DisplayName = question.User.GetDisplayName(),
                            Created = question.Created,
                            Text = question.Text,
                            UserId = question.OwnerUserId,
                            QuestionId = question.QuestionID,
                            OwnerUserId = question.OwnerUserId
                        }));

            return (from x in posts orderby x.Created descending select x).ToList();
        }

        public void DeleteQuestion(int questionId)
        {
            var answers = from answer in Entities.Answer where answer.QuestionID == questionId select answer;
            foreach (var answer in answers)
                Entities.DeleteObject(answer);

            Entities.DeleteObject(Entities.Question.First(x => x.QuestionID == questionId));

            Entities.SaveChanges();
        }

        public void DeleteAnswer(int answerId)
        {
            Entities.DeleteObject(Entities.Answer.First(answer => answer.AnswerID == answerId));

            Entities.SaveChanges();
        }

        public bool DeleteAllowed(Question question, Guid userId)
        {
            bool notLoggedIn = userId == Guid.Empty;
            
            // logged In?
            bool deleteAllowed = !notLoggedIn && (userId == question.OwnerUserId);

            // owner?
            deleteAllowed = question.OwnerUserId == userId;

            return deleteAllowed;
        }

        public bool DeleteAllowed(Answer answer, Guid userId)
        {
            bool loggedIn = userId != Guid.Empty;

            // logged In?
            bool deleteAllowed = loggedIn && (userId == answer.UserId);

            // owner of answer?
            deleteAllowed = answer.UserId == userId;

            // owner of question?
            deleteAllowed = deleteAllowed || (answer.Question.OwnerUserId == userId);

            return deleteAllowed;
        }
    }
}
