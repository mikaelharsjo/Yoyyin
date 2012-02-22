using System;
using System.Linq;

namespace Yoyyin.Data
{
    public interface IBookmarkRepository
    {
        IQueryable<UserBookmarks> Find();
        void Save();
        void Delete(UserBookmarks entity);
        void Add(UserBookmarks entity);
        UserBookmarks Create();
    }

    public class EntityUserBookmarksRepository : IBookmarkRepository
    {
        private readonly YoyyinEntities1 _entities;

        public EntityUserBookmarksRepository(YoyyinEntities1 entities)
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