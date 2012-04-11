using System;
using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Domain.Users;

namespace Yoyyin.Domain.Services
{
    public interface IUserService
    {
        IEnumerable<IUser> SearchAdvanced(string text, bool isEntrepreneur, bool isInnovator, bool isInvestor, string sniNo);
        IEnumerable<IUser> SearchQuick(string textToMatch);
        IEnumerable<User> GetLastActiveUsersWithImage();
        //IEnumerable<IUser> GetAllUsersIncludingSni();
        //IEnumerable<Guid> GetUserIDsWithMostVisits();
        int GetNumberOfUsers();
        IEnumerable<IUser> GetUsersBySni(string sniHeadID);
        //void DeleteUser(Guid userId);
        //void Save(IUser user);
        //void CreateUserInDb(IUser user);
        //IEnumerable<IUser> GetAllUsers();
        //IEnumerable<IUser> GetUsersWithSniHeadOf(string sniHead);
        //IUser GetUser(Guid userId);
        void RemoveImage(IUser user);
        void RemoveCv(IUser user);
        void InActivateUser(IUser user);
        IUser GetCurrentUser();
    }
}