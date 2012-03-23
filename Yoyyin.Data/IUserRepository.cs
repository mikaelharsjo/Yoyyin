using System;
using System.Linq;

namespace Yoyyin.Data
{
    public interface IUserRepository : IRepository<IUser>
    {

        IQueryable<Guid> GetUserIDsWithMostVisits();
        //int GetNumberOfUsers();
        //IQueryable<User> GetAllUsersIncludingSni();
    }
}