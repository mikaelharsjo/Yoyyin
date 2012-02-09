using System;
using System.Linq;

namespace Yoyyin.Data
{
    public class EntityCommentsRepository : IRepository<UserComments>
    {
        private readonly YoyyinEntities1 _entities;

        public EntityCommentsRepository(YoyyinEntities1 entities1)
        {
            _entities = entities1;
        }

        public IQueryable<UserComments> Find()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void Delete(UserComments comment)
        {
            _entities.DeleteObject(comment);
        }

        public void Add(UserComments entity)
        {
            throw new NotImplementedException();
        }

        public UserComments Create()
        {
            throw new NotImplementedException();
        }
    }
}