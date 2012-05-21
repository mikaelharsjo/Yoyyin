using System;
using System.Linq;
using Yoyyin.Data.Core.Entities;

namespace Yoyyin.Data.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IUser GetUser(Guid userId);
        IQueryable<User> GetLastActiveUsersWithImage();
    }
}