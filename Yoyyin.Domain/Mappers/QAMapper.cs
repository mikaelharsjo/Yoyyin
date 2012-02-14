using Yoyyin.Domain.QA;

namespace Yoyyin.Domain.Mappers
{
    public class QAMapper : IQAMapper
    {
        private readonly IUserMapper _userMapper;

        public QAMapper(IUserMapper userMapper)
        {
            _userMapper = userMapper;
        }

        public QA.Question MapQuestion(Data.Question questionData)
        {
            return new QA.Question
                       {
                           Created = questionData.Created,
                           //Category = _categoryFactory.CreateCategory((CategoryType)questionData.Category, this), // TODO fix later, strange dependency
                           Owner = _userMapper.MapUser(questionData.User),
                           Text = questionData.Text,
                           Title = questionData.Title
                       };
        }

        public Answer MapAnswer(Data.Answer answerData)
        {
            return new Answer
                       {
                           AnswerID = answerData.AnswerID,
                           Created = answerData.Created,
                           Question = MapQuestion(answerData.Question),
                           Text = answerData.Text,
                           User = _userMapper.MapUser(answerData.User)
                       };
        }
    }
}