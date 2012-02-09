using System;
using System.Collections.Generic;
using System.Linq;
using Zitac.Trinity.Business.Extensions;
using System.Data.Objects;

namespace Yoyyin.Domain.EntityHelpers
{
    public class UserHelper : EntityBase
    {
        public void LogMemberVisit(Guid visitingUserID, Guid userID)
        {
            if (visitingUserID == userID)
                return;

            var visit = Entities.UserVisits.FirstOrDefault(x => x.VisitingUserId == visitingUserID && x.UserId == userID);

            if (visit == null) // first time
            {
                visit = new UserVisits {UserId = userID, VisitingUserId = visitingUserID};
                Entities.UserVisits.AddObject(visit);
            }

            visit.TimeStamp = DateTime.Now;
            Entities.SaveChanges();
        }

        public void LogAnonymousVisit(Guid userID)
        {
            UserVisits visit = Entities.UserVisits.FirstOrDefault(x => x.VisitingUserId == null && x.UserId == userID);
            if (visit == null)
            {
                visit = new UserVisits();
                Entities.UserVisits.AddObject(visit);
            }
            visit.VisitingUserId = null;
            visit.UserId = userID;

            visit.TimeStamp = DateTime.Now;
            Entities.SaveChanges();
        }

        public List<UserMessages> GetOutBoxMessages(Guid userID)
        {
            return (from x in Entities.UserMessages.Include("User") orderby x.TimeStamp descending where x.FromUserId == userID select x).ToList();
        }

        public List<UserMessages> GetInBoxMessages(Guid userID)
        {
            return (from x in Entities.UserMessages.Include("User") orderby x.TimeStamp descending where x.ToUserId == userID select x).ToList();
        }

        public List<UserBookmarks> GetBookmarks(Guid userID)
        {
            return (from x in Entities.UserBookmarks where x.UserId == userID orderby x.TimeStamp descending select x).ToList();
        }

        public List<UserVisits> GetVisits(Guid userID)
        {
            return (from x in Entities.UserVisits where x.UserId == userID orderby x.TimeStamp descending select x).ToList();
        }

        public List<User> SearchAdvanced(string text, bool isEntrepreneur, bool isInnovator, bool isInvestor, string sniNo)
        {
            var users = Entities.User.ToList(); // optimize?
            if (isEntrepreneur)
                users = users.FindAll(x => x.UserType != null && (int)x.UserType == (int)UserTypes.Entrepreneur).ToList();
            if (isInnovator)
                users = users.FindAll(x => x.UserType != null && (int)x.UserType == (int)UserTypes.Innovator).ToList();
            if (isInvestor)
                users = users.FindAll(x => x.UserType != null && (int)x.UserType == (int)UserTypes.Investor).ToList();

            if (sniNo != "0")
                users = users.FindAll(x => x.SniHeadID == sniNo);

            if (!String.IsNullOrEmpty(text))
                users = users.FindAll(x => (x.Name.Contains(text) || x.BusinessDescription.Contains(text)));

            return users;
        }

        public List<User> SearchQuick(string textToMatch)
        {
            return (from x in Entities.User where x.SearchWordsCompetence.Contains(textToMatch) || x.BusinessDescription.Contains(textToMatch) || x.City.Contains(textToMatch) || x.Street.Contains(textToMatch) || x.ZipCode.Contains(textToMatch) || x.BusinessTitle.Contains(textToMatch) || x.Name.Contains(textToMatch) || x.SearchWords.Contains(textToMatch) || x.SniHead.Title.Contains(textToMatch) || x.SniItem.Title.Contains(textToMatch) && x.Active == true select x).ToList();
        }

        public List<UserComments> GetComments(Guid userID)
        {
            return (from x in Entities.UserComments where x.UserId == userID select x).ToList();
        }

        public List<User> GetLastActiveUsersWithImage()
        {
            return (from x in Entities.User orderby x.aspnet_Users.LastActivityDate descending where x.Image != null select x).ToList();
        }

        public IEnumerable<User> GetAllUsersIncludingSni()
        {
            return (from x in Entities.User.Include("SniHead").Include("SniItem") where x.Active == true && !string.IsNullOrEmpty(x.SniHeadID) orderby x.SniHeadID, x.SniNo select x);
        }

        public List<Guid> GetUserIDsWithMostVisits()
        {
            return Entities.ExecuteFunction<Guid>(Constants.SqlPopular, new ObjectParameter[0]).ToList<Guid>();
        }

        public int GetNumberOfUsers()
        {
            ObjectResult<int> count = Entities.ExecuteFunction<int>(Constants.SqlCount, new ObjectParameter[0]);
            return count.FirstOrDefault();
        }

        public List<User> GetUsersBySni(string sniHeadID)
        {
            return (from x in Entities.User where x.SniHeadID == sniHeadID select x).ToList<User>();
        }

        public UserComments CreateAndSaveComment(string fromUserId, string toUserId, string text, int commentID)
        {
            var comment = Entities.CreateObject<UserComments>();
            Entities.UserComments.AddObject(comment);

            comment.Text = text.TruncateText(1000);
            comment.CommentUserId = new Guid(fromUserId);
            comment.UserId = new Guid(toUserId);
            comment.TimeStamp = DateTime.Now;
            if (commentID > 0)
                comment.CommentCommentID = commentID;

            Entities.SaveChanges();

            return comment;
        }

        public void DeleteUser(Guid userId)
        {
            var messages = from x in Entities.UserMessages where x.FromUserId == userId select x;
            foreach (UserMessages message in messages)
                Entities.DeleteObject(message);

            var messages2 = from x in Entities.UserMessages where x.ToUserId == userId select x;
            foreach (UserMessages message in messages2)
                Entities.DeleteObject(message);

            var comments = from x in Entities.UserComments where x.CommentUserId == userId select x;
            foreach (UserComments comment in comments)
                Entities.DeleteObject(comment);

            comments = from x in Entities.UserComments where x.UserId == userId select x;
            foreach (UserComments comment in comments)
                Entities.DeleteObject(comment);

            var visits = from x in Entities.UserVisits where x.UserId == userId select x;
            foreach (UserVisits visit in visits)
                Entities.DeleteObject(visit);

            visits = from x in Entities.UserVisits where x.VisitingUserId == userId select x;
            foreach (UserVisits visit in visits)
                Entities.DeleteObject(visit);

            var bookmarks = from x in Entities.UserBookmarks where x.UserId == userId select x;
            foreach (UserBookmarks bookmark in bookmarks)
                Entities.DeleteObject(bookmark);

            bookmarks = from x in Entities.UserBookmarks where x.BookmarkedUserID == userId select x;
            foreach (UserBookmarks bookmark in bookmarks)
                Entities.DeleteObject(bookmark);

            Entities.DeleteObject(Entities.User.FirstOrDefault(x => x.UserId == userId));

            Entities.SaveChanges();
        }

        public void Save(User user)
        {
            using (var entities = new YoyyinEntities1())
            {
                User userToSave = entities.User.First(x => x.UserId == user.UserId);

                userToSave.ZipCode = user.ZipCode;
                userToSave.Active = user.Active;
                userToSave.Alias = user.Alias;
                userToSave.BusinessDescription = user.BusinessDescription;
                userToSave.BusinessTitle = user.BusinessTitle;
                userToSave.City = user.City;
                userToSave.CompanyName = user.CompanyName;
                userToSave.CVFileName = user.CVFileName;
                userToSave.DescBusinessman = user.DescBusinessman;
                userToSave.DescEntrepreneur = user.DescEntrepreneur;
                userToSave.DescFinancing = user.DescFinancing;
                userToSave.DescInnovator = user.DescInnovator;
                userToSave.DescInvestor = user.DescInvestor;
                userToSave.DescRetiring = user.DescRetiring;
                userToSave.FacebookID = user.FacebookID;
                userToSave.ForumUserID = user.ForumUserID;
                userToSave.Image = user.Image;
                userToSave.Latitude = user.Latitude;
                userToSave.Longitude = user.Longitude;
                userToSave.Name = user.Name;
                userToSave.Phone = user.Phone;
                userToSave.SearchWords = user.SearchWords;
                userToSave.SearchWordsCompetence = user.SearchWordsCompetence;
                userToSave.SearchWordsCompetenceNeeded = user.SearchWordsCompetenceNeeded;
                userToSave.ShowAddress = user.ShowAddress;
                userToSave.ShowEmail = user.ShowEmail;
                userToSave.ShowOnMap = user.ShowOnMap;
                userToSave.SniHeadID = user.SniHeadID;
                userToSave.SniNo = user.SniNo;
                userToSave.Street = user.Street;
                userToSave.Url = user.Url;
                userToSave.UserType = user.UserType;
                userToSave.UserTypeDescription = user.UserTypeDescription;
                userToSave.UserTypesNeeded = user.UserTypesNeeded;

                entities.SaveChanges();
            }
        }

        public void CreateUserInDb(User user)
        {
            using (var entities = new YoyyinEntities1())
            {
                entities.User.AddObject(user);
                entities.SaveChanges();
            }
        }

        public void CreateAndSaveBookmark(Guid userID, Guid bookmarkUserID)
        {
            var bookmark = new UserBookmarks
                                         {BookmarkedUserID = bookmarkUserID, UserId = userID, TimeStamp = DateTime.Now};

            Entities.UserBookmarks.AddObject(bookmark);

            try
            {
                Entities.SaveChanges();
            }
            catch 
            { 
                // could already be added 
            }
        }

        public void DeleteBookmark(Guid userID, Guid bookmarkUserID)
        {
            UserBookmarks bookmark = Entities.UserBookmarks.First(x => x.UserId == userID && x.BookmarkedUserID == bookmarkUserID);
            Entities.DeleteObject(bookmark);
            Entities.SaveChanges();
        }

        public void DeleteComment(int commentID)
        {
            var childComments = from x in Entities.UserComments where x.CommentCommentID == commentID select x;
            foreach (UserComments childComment in childComments)
            {
                RemoveSingleComment(childComment.CommentID);
            }

            RemoveSingleComment(commentID);
            Entities.SaveChanges();
        }

        private void RemoveSingleComment(int commentID)
        {
            UserComments comment = Entities.UserComments.First(x => x.CommentID == commentID);
            Entities.DeleteObject(comment);            
        }

        public void CreateAndSaveUserMessage(string fromUserId, string toUserId, string message)
        {
            var userMessage = Entities.CreateObject<UserMessages>();

            Entities.UserMessages.AddObject(userMessage);

            userMessage.FromMessage = message.TruncateText(400);
            userMessage.FromUserId = new Guid(fromUserId);
            userMessage.ToUserId = new Guid(toUserId);
            userMessage.TimeStamp = DateTime.Now;

            Entities.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            // we wan´t to enumerate here so we can dispose the ObjectContext instance
            return Entities.User.Include("SniHead").Include("SniItem").ToList();
        }

        public List<SniItem> GetSniItemsByHead(string sniHeadID)
        {
            return (from x in Entities.SniItem where x.SniHeadID == sniHeadID select x).ToList();
        }

        public List<SniHead> GetAllSniHeads()
        {
            return Entities.SniHead.ToList();
        }
    }
}
