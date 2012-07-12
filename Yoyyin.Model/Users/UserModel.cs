using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.ValueObjects;

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

            SniHeads = new List<SniHead>();
            Users = new List<User>();
            UserTypes = new List<UserType>();
        }

        // indexes
        public ILookup<string, User> UsersByCategory { get; set; }
        public ILookup<Guid, Question> QuestionsByUser { get; set; }

        //public List<Question> Questions { get; set; }

        public List<User> Users { get; set; }
        public List<SniHead> SniHeads { get; set; }
        public List<UserType> UserTypes { get; set; }

        public void Invalidate()
        {
            //UsersByCategory = Users.ToLookup(u => u.Category.CategoryId);
            //QuestionsByUser = Questions.ToLookup(q => q.UserId);
        }
    }
}
