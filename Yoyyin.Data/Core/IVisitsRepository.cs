using System.Linq;

namespace Yoyyin.Data
{
    public interface IVisitsRepository<UserVisits>
    {
        IQueryable<Visit> Find();
        void Save();
        void Delete(Visit entity);
        void Add(UserVisits visit);
        UserVisits Create();
    }
}