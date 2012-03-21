using System;
using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Domain.QA;

namespace Yoyyin.Domain.Services
{
    public interface IQAService
    {
        //void CreateQuestionInDb(Question question);
        //void CreateAnswerInDb(Answer answer);
        IEnumerable<Question> GetQuestionsByCategory(ICategory category);
        //IList<Question> GetQuestionsByUser(Guid userID);
        Question GetLatestQuestionByCategory(ICategory category);
        //IList<Answer> GetAnswersByUser(Guid userID);
        //IEnumerable<Answer> GetAnswersByQuestion(int questionId);
        //int GetNumberOfAnswersByQuestion(int questionId);
        //void DeleteQuestion(int questionId);
        //void DeleteAnswer(int answerId);
        //bool DeleteAllowed(Question question, Guid userId);
        //IEnumerable<Post> GetLatestPosts(int maxPosts);
        ////Question GetQuestion(int questionID);
        //IEnumerable<Post> GetPostsByUser(Guid userId);
    }
}