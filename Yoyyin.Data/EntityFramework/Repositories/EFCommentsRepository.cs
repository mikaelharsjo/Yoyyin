using System;
using System.Linq;

namespace Yoyyin.Data.EntityFramework
{
    public class EFCommentsRepository : ICommentsRepository
    {
        private readonly YoyyinEntities1 _entities;

        public EFCommentsRepository(YoyyinEntities1 entities1)
        {
            _entities = entities1;
        }

        public IQueryable<UserComments> Find()
        {
            return _entities.UserComments;
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