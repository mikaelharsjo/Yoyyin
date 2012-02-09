using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yoyyin.Data
{
    public class EntityQARepository : IEntityQARepository
    {
        private readonly YoyyinEntities1 _entities;

        public EntityQARepository(YoyyinEntities1 entities)
        {
            _entities = entities;
        }

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

        public IQueryable<Question> GetQuestionsByCategory(int category)
        {
            return from x in _entities.Question.Include("User") where x.Category == category orderby x.Created descending select x;
        }

        public IQueryable<Question> GetQuestionsByUser(Guid userID)
        {
            return from x in _entities.Question where x.OwnerUserId == userID select x;
        }

        public Question GetLatestQuestionByCategory(int category)
        {
            return
                (from x in _entities.Question where x.Category == category orderby x.Created descending select x).FirstOrDefault();
        }

        public IQueryable<Question> GetLatestQuestions(int maxCount)
        {
            return (from x in _entities.Question orderby x.Created select x).Take(maxCount);
        }

        public IQueryable<Answer> GetLatestAnswers(int maxCount)
        {
            return (from x in _entities.Answer orderby x.Created select x).Take(maxCount);
        }

        public Question GetQuestion(int questionID)
        {
            return _entities.Question.First(q => q.QuestionID == questionID);
        }

        public IQueryable<Answer> GetAnswersByUser(Guid userID)
        {
            return from x in _entities.Answer where x.UserId == userID select x;
        }

        public IQueryable<Answer> GetAnswersByQuestion(int questionId)
        {
            return from x in _entities.Answer.Include("User") where x.QuestionID == questionId select x;
        }

        public int GetNumberOfAnswersByQuestion(int questionId)
        {
            // optimixe with entity command?
            return (from x in _entities.Answer where x.QuestionID == questionId select x).Count();
        }

        public void DeleteQuestion(int questionId)
        {
            var answers = from answer in _entities.Answer where answer.QuestionID == questionId select answer;
            foreach (var answer in answers)
                _entities.DeleteObject(answer);

            _entities.DeleteObject(_entities.Question.First(x => x.QuestionID == questionId));

            _entities.SaveChanges();
        }

        public void DeleteAnswer(int answerId)
        {
            _entities.DeleteObject(_entities.Answer.First(answer => answer.AnswerID == answerId));

            _entities.SaveChanges();
        }
    }
}
