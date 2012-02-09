using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;

namespace Yoyyin.Tests
{
    public class TestUserRepository : IUserRepository
    {
        private readonly IList<Data.User> _users;
 
        public TestUserRepository()
        {
            _users = new List<Data.User> { new Data.User { SniHeadID = "A", Name = "Kalle Anka", UserId = new Guid("11111111-1111-1111-1111-111111111111") } };
        }

        public void LogMemberVisit(Guid visitingUserID, Guid userID)
        {
            throw new NotImplementedException();
        }

        public void LogAnonymousVisit(Guid userID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserMessages> GetOutBoxMessages(Guid userID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserMessages> GetInBoxMessages(Guid userID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserBookmarks> GetBookmarks(Guid userID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserVisits> GetVisits(Guid userID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> SearchAdvanced(string text, bool isEntrepreneur, bool isInnovator, bool isInvestor, string sniNo)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> SearchQuick(string textToMatch)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserComments> GetComments(Guid userID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetLastActiveUsersWithImage()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAllUsersIncludingSni()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> Find()
        {
            return _users.AsQueryable();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public User Create()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Guid> GetUserIDsWithMostVisits()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfUsers()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUsersBySni(string sniHeadID)
        {
            throw new NotImplementedException();
        }

        public UserComments CreateAndSaveComment(string fromUserId, string toUserId, string text, int commentID)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }

        public void CreateUserInDb(User user)
        {
            throw new NotImplementedException();
        }

        public void CreateAndSaveBookmark(Guid userID, Guid bookmarkUserID)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookmark(Guid userID, Guid bookmarkUserID)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int commentID)
        {
            throw new NotImplementedException();
        }

        public void RemoveSingleComment(int commentID)
        {
            throw new NotImplementedException();
        }

        public void CreateAndSaveUserMessage(string fromUserId, string toUserId, string message)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IQueryable<SniItem> GetSniItemsByHead(string sniHeadID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SniHead> GetAllSniHeads()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUsersWithSniHeadOf(string sniHead)
        {
            return _users
                .Where(user => user.SniHeadID == sniHead)
                .AsQueryable();
        }
    }
}