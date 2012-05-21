using System;
using System.Linq;

namespace Yoyyin.Data.EntityFramework
{
    public class EFUserVisitsRepository : IVisitsRepository
    {
        private readonly YoyyinEntities1 _entities;

        public EFUserVisitsRepository(YoyyinEntities1 entities)
        {
            _entities = entities;
        }

        public IQueryable<UserVisits> Find()
        {
            return _entities.UserVisits;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void Delete(UserVisits entity)
        {
            throw new NotImplementedException();
        }

        public void Add(UserVisits visit)
        {
            _entities.UserVisits.AddObject(visit);
        }

        public UserVisits Create()
        {
            throw new NotImplementedException();
        }
    }
}