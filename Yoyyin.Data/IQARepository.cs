using System;
using System.Linq;

namespace Yoyyin.Data
{
    public interface IQARepository
    {
        void CreateQuestionInDb(Question question);
        void CreateAnswerInDb(Answer answer);
        IQueryable<Question> GetQuestionsByCategory(int category);
        IQueryable<Question> GetQuestionsByUser(Guid userID);
        Question GetLatestQuestionByCategory(int category);
        IQueryable<Answer> GetAnswersByUser(Guid userID);
        IQueryable<Answer> GetAnswersByQuestion(int questionId);
        int GetNumberOfAnswersByQuestion(int questionId);
        void DeleteQuestion(int questionId);
        void DeleteAnswer(int answerId);
        IQueryable<Question> GetLatestQuestions(int maxCount);
        IQueryable<Answer> GetLatestAnswers(int maxCount);
        Question GetQuestion(int questionID);
    }
}