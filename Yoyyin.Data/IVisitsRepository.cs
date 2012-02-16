using System.Linq;

namespace Yoyyin.Data
{
    public interface IVisitsRepository
    {
        IQueryable<UserVisits> Find();
        void Save();
        void Delete(UserVisits entity);
        void Add(UserVisits visit);
        UserVisits Create();
    }
}