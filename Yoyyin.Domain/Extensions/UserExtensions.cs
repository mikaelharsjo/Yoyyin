using Yoyyin.Data;
using Yoyyin.Data.Core;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Domain.Users;


namespace Yoyyin.Domain.Extensions
{
    public static class UserExtensions
    {
        //public static void LogMemberVisit(this User user, Guid visitingUserID, IUserService userService)
        //{
        //    userService.LogMemberVisit(visitingUserID, user.UserId);
        //}

        //public static void LogAnonymousVisit(this User user, IUserService userService)
        //{
        //    userService.LogAnonymousVisit(user.UserId);
        //}

        //public static List<UserMessages> GetOutBoxMessages(this User user, IMessagesService userService)
        //{
        //    return userService.GetOutBoxMessages(user.UserId);
        //}

        //public static List<UserMessages> GetInBoxMessages(this User user, IUserService userService)
        //{
        //    return userService.GetInBoxMessages(user.UserId);
        //}

        //public static List<Bookmark> GetBookmarks(this User user, IUserService userService)
        //{
        //    return userService.GetBookmarks(user.UserId);
        //}

        //public static List<Visit> GetVisits(this User user, IUserService userService)
        //{
        //    return userService.GetVisits(user.UserId);           
        //}

        //public static bool ShowFacebookImage(this User user)
        //{
        //    if (string.IsNullOrEmpty(user.FacebookID) || user.Image != null)
        //        return false;
        //    return true;
        //}

        //public static string ShowFacebookImageAsStyle(this User user)
        //{
        //    if (user.ShowFacebookImage())
        //        return string.Empty;
            
        //    return "display: none;";
        //}

        //public static IList<Comment> GetComments(this User user, IUserService userService)
        //{
        //    return userService.GetComments(user.UserId); 
        //}

        //public static void Save(this User user, IUserService userService)
        //{
        //    userService.Save(user);
        //}

        //public static void InActivate(this User user, IUserService userService)
        //{
        //    user.Active = false;
        //    user.Save(userService);
        //}

        //public static void RemoveImage(this User user, IUserService userService)
        //{
        //    user.Image = null;
        //    user.Save(userService);
        //}

        //public static void RemoveCv(this User user, IUserService userService)
        //{
        //    user.CVFileName = string.Empty;
        //    user.Save(userService);
        //}

        //public static IList<Question> GetQuestions(this User user, IUserService userService)
        //{
        //    return userService.GetQuestionsByUser(user.UserId);
        //}

        //public static IEnumerable<Post> GetPosts(this User user, IUserService userService)
        //{
        //    return userService.GetPostsByUser(user.UserId);
        //}

        public static string GetDisplayName(this IUser user)
        {
            return string.IsNullOrEmpty(user.Alias) ? user.Name : user.Alias;
        }

        //public static string GetDisplayName(this User user)
        //{
        //    return string.IsNullOrEmpty(user.Alias) ? user.Name : user.Alias;
        //}

        public static string GetProfileUrl(this IUser user)
        {
            return "Member.aspx?UserID=" + user.UserId;
        }

        //public static string GetProfileUrl(this User user)
        //{
        //    return "Member.aspx?UserID=" + user.UserId;
        //}

        public static string GetUserName(this IUser user)
        {
            return string.Empty;

        }
    }
}
