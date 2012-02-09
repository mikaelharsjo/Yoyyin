using System;
using System.Linq;

namespace Yoyyin.Domain.EntityHelpers
{
    public class EntityFactory : EntityBase
    {
        public User GetUser(object userID)
        {
            var userGuid = new Guid(userID.ToString());

            User user = Entities.User.FirstOrDefault(x => x.UserId == userGuid);
            return user ?? new User();
        }

        //public SniHead GetSniHead(string sniHeadID)
        //{
        //    return Entities.SniHead.FirstOrDefault(x => x.SniHeadID == sniHeadID);
        //}

        //public SniItem GetSniItem(string sniNo)
        //{
        //    return Entities.SniItem.FirstOrDefault(x => x.SniNo == sniNo);
        //}

        //public UserMessages GetUserMessage(int userMessagesID)
        //{
        //    return Entities.UserMessages.First(x => x.UserMessagesID == userMessagesID);
        //}

        public Question GetQuestion(int questionID)
        {
            return Entities.Question.First(x => x.QuestionID == questionID);
        }
    }
}
