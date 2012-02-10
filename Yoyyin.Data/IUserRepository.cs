using System;
using System.Linq;

namespace Yoyyin.Data
{
    public interface IUserRepository
    {
        IQueryable<User> Find();
        void Save();
        void Delete(User entity);
        void Add(User entity);
        User Create();
        IQueryable<Guid> GetUserIDsWithMostVisits();
        int GetNumberOfUsers();
        IQueryable<User> GetAllUsersIncludingSni();
    }
}