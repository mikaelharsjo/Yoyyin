using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Users
{
    public class QandAModel
    {
        // Basedata should be the only serialized datamember since the rest are calculated or application state dependent
        //[DataMember]
        //public BaseData BaseData { get; set; }

        public QandAModel()
        {
          //  BaseData = new BaseData();
            Invalidate();

            Questions = new List<Question>();
        }

        // indexes
        public ILookup<Guid, Question> QuestionsByUser { get; set; }

        public List<Question> Questions { get; set; }


        public void Invalidate()
        {
            //UsersByCategory = Users.ToLookup(u => u.Category.CategoryId);
            //QuestionsByUser = Questions.ToLookup(q => q.UserId);
        }
    }
}
