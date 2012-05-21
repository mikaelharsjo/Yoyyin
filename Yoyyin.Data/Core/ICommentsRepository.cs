using System.Linq;

namespace Yoyyin.Data
{
    public interface ICommentsRepository
    {
        IQueryable<UserComments> Find();
        void Save();
        void Delete(UserComments comment);
        void Add(UserComments entity);
        UserComments Create();
    }
}