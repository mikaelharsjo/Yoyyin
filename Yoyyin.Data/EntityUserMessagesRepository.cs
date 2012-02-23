using System;
using System.Linq;

namespace Yoyyin.Data
{
    public interface IUserMessagesRepository
    {
        IQueryable<UserMessages> Find();
        void Save();
        void Delete(UserMessages entity);
        UserMessages Create();
        void Add(UserMessages message);
    }

    public class EntityUserMessagesRepository : IUserMessagesRepository
    {
        private readonly YoyyinEntities1 _entities;

        public EntityUserMessagesRepository(YoyyinEntities1 entities1)
        {
            _entities = entities1;
        }

        public IQueryable<UserMessages> Find()
        {
            return _entities.UserMessages;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Delete(UserMessages entity)
        {
            throw new NotImplementedException();
        }

        public UserMessages Create()
        {
            return _entities.CreateObject<UserMessages>();
        }

        public void Add(UserMessages message)
        {
            _entities.UserMessages.AddObject(message);
        }
    }
}