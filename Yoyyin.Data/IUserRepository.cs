using System;
using System.Linq;
using Yoyyin.Domain.Users;

namespace Yoyyin.Data
{
    public interface IUserRepository : IRepository<IUser>
    {

        IQueryable<Guid> GetUserIDsWithMostVisits();
        //int GetNumberOfUsers();
        //IQueryable<User> GetAllUsersIncludingSni();
    }
}