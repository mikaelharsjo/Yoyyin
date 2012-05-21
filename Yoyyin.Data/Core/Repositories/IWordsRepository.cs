using System.Linq;

namespace Yoyyin.Data.Core.Repositories
{
    public interface IWordsRepository
    {
        IQueryable Find();
    }
}