using System;
using System.Linq;

namespace Yoyyin.Data.EntityFramework
{
    public class EFUserBookmarksRepository : IBookmarkRepository
    {
        private readonly YoyyinEntities1 _entities;

        public EFUserBookmarksRepository(YoyyinEntities1 entities)
        {
            _entities = entities;
        }

        public IQueryable<UserBookmarks> Find()
        {
            return _entities.UserBookmarks;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void Delete(UserBookmarks entity)
        {
            throw new NotImplementedException();
        }

        public void Add(UserBookmarks entity)
        {
            _entities
                .UserBookmarks
                .AddObject(entity);
        }

        public UserBookmarks Create()
        {
            throw new NotImplementedException();
        }
    }
}