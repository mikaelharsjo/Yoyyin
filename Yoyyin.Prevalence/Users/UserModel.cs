using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Users
{
    public class UserModel
    {
        // Basedata should be the only serialized datamember since the rest are calculated or application state dependent
        //[DataMember]
        //public BaseData BaseData { get; set; }

        public UserModel()
        {
          //  BaseData = new BaseData();
            Invalidate();

            Questions = new List<Question>();
            Users = new List<User>();
        }

        // indexes
        public ILookup<string, User> UsersByCategory { get; set; }
        public ILookup<Guid, Question> QuestionsByUser { get; set; }

        public List<Question> Questions { get; set; }

        public List<User> Users { get; set; }

        public void Invalidate()
        {
            //UsersByCategory = Users.ToLookup(u => u.Category.CategoryId);
            //QuestionsByUser = Questions.ToLookup(q => q.UserId);
        }
    }
}
