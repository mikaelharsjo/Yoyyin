using System;
using System.Linq;

namespace Yoyyin.Data
{
    public interface IUserRepository : IRepository<IUser>
    {
        IUser GetUser(Guid userId);
        IQueryable<Guid> GetUserIDsWithMostVisits();
        //int GetNumberOfUsers();
        //IQueryable<User> GetAllUsersIncludingSni();
    }
}