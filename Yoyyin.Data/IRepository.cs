using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yoyyin.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> Find();
        void Save();
        void Delete(T entity);
        void Add(T entity);
        T Create();
    }
}
