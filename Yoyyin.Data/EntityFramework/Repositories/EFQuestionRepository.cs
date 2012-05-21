using System;
using System.Data.Objects;
using System.Linq;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Data.EntityFramework.Repositories
{
    public class EFQuestionRepository : EFRepository<Question>, IQuestionRepository
    {
        private readonly ObjectContext _context;
        public EFQuestionRepository(ObjectContext context) : base(context)
        {
            _context = context;
        }

        public void CreateQuestionInDb(Question question)
        {
            using (var entities = new YoyyinEntities1())
            {
                entities.Question.AddObject(question);
                entities.SaveChanges();
            }
        }

        public IQueryable<Question> GetQuestionsByCategory(int category)
        {
            return from x in ObjectSet.Include("User") where x.Category == category orderby x.Created descending select x;
        }

        public IQueryable<Question> GetQuestionsByUser(Guid userID)
        {
            return from x in ObjectSet where x.OwnerUserId == userID select x;
        }

        public Question GetLatestQuestionByCategory(int category)
        {
            return ObjectSet
                    .Include("User")
                    .Where(q => q.Category == category)
                    .OrderByDescending(q => q.Created)
                    .First();
        }
    }
}
