using System.Linq;

namespace Yoyyin.Data
{
    public interface IEntityWordsRepository
    {
        IQueryable Find();
    }
}