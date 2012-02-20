using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Security;
using System.Web.UI.WebControls;
using Yoyyin.Domain;
using Yoyyin.Domain.Enumerations;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;

namespace Yoyyin.Web.Helpers
{
    /// <summary>
    /// Summary description for Helpers
    /// </summary>
    public class WebHelpers
    {
        const string MemberUrl = "Member.aspx?UserID={0}";
        public const string FacebookImageurlSmall = "https://graph.facebook.com/{0}/picture";
        public const string FacebookImageurlLarge = "https://graph.facebook.com/{0}/picture?type=large";
        public const string MailFooter2 = "<br/><br/>Hälsningar Anders, Peter & Mikael på Yoyyin";
        public IUserService UserService { get; set; }

        public static string GetOnlineImageUrl2(object userId)
        {
            if (userId == null)
                return "~/Styles/Images/empty.gif";
            
            return GetOnlineImageUrl(Membership.GetUser(new Guid(userId.ToString())));
        }

        public static string GetUserUrl(object userId)
        {
            if (userId == null)
                return "#";
            return string.Format(MemberUrl, userId);
        }

        //public static string GetDisplayName(object userId)
        //{
        //    if (userId == null)
        //        return "Inte inloggad";
            
        //    Guid gUserId = new Guid(userId.ToString());
        //    var user = UserService.GetUser(gUserId);
        //    if (!string.IsNullOrEmpty(user.Alias))
        //        return user.Alias;
        
        //    if (!string.IsNullOrEmpty(user.Name))
        //        return user.Name;
            
        //    return "Inte angivit";
        //}

        public static string GetCurrentUserName()
        {
            var membershipUser = Membership.GetUser();
            if (membershipUser != null) return membershipUser.UserName;

            return "";
        }

        public static string GetEmail(object userID)
        {
            var mu = Membership.GetUser(userID);
            return mu == null ? string.Empty : mu.Email;
        }

        public static Guid GetGuidOfCurrentlyLoggedInUser()
        {
            var mu = Membership.GetUser();
            
            if (mu != null)
            {
                if (mu.ProviderUserKey != null) return new Guid(mu.ProviderUserKey.ToString());
            }

            return Guid.Empty;
        }

        public static bool IsLoggedIn()
        {
            return GetGuidOfCurrentlyLoggedInUser() != Guid.Empty;
        }


        public static void DeleteMembershipUser(Guid userID)
        {
            string userName = Membership.GetUser(userID).UserName;
            Membership.DeleteUser(userName, true);
        }

        public static bool HasFacebook(object dataItem)
        {
            var user = GetUserFromDataItem(dataItem);

            if (ShowFaceBookImage(user))
                return false;
            
            return true;
        }

        public static string HideFaceBookImage(IUser user)
        {
            if (!ShowFaceBookImage(user))
                return "display: none";
            else
                return string.Empty;
        }

        public static bool ShowFaceBookImage(IUser user)
        {
            bool hasFacebook = !string.IsNullOrEmpty(user.FacebookID);
            bool hasYoyyinImage = user.Image != null;
            return hasFacebook && !hasYoyyinImage;
        }

        public static string GetFbUrl(object dataItem)
        {        
            var user = GetUserFromDataItem(dataItem);

            return ShowFaceBookImage(user) ? string.Format(FacebookImageurlSmall, user.FacebookID) : string.Empty;
        }

        private static IUser GetUserFromDataItem(object dataItem)
        {
            var user = new User();

            if (dataItem is User)
                user = (User)dataItem;
            else if (dataItem is Comment)
            {
                Comment comment = (Comment)dataItem;
                user = (User) comment.User; //entityFactory.GetUser(comment.CommentUserId);
            }

            // TODO: fix
            //else if (dataItem is Guid)
            //    user = UserService.GetUser(dataItem)
            return user;
        }

        public static string InaccesibleIfNotLoggedIn()
        {
            if (!IsLoggedIn())
                return "secretLink";
            else
                return string.Empty;
        }

        public static string GetDate(object dataItem)
        {
            return GetDate(dataItem, false);
        }

        public static string GetDate(object dataItem, bool shortDate)
        {
            DateTime date = new DateTime();
            if (dataItem is DataRowView)
            {
                DataRowView drv = (DataRowView)dataItem;
                date = Convert.ToDateTime(drv.Row["LastPosted"]);
            }
            else
            {
                PropertyInfo pInfo = dataItem.GetType().GetProperties().First(x => x.Name == "TimeStamp");
                date = (DateTime)pInfo.GetValue(dataItem, null);
            }

            if (shortDate)
                return date.ToShortDateString();
            
            return date.ToFormattedString();
        }

        public static string GetOnlineImageUrl(object dataItem)
        {
            var mu = (MembershipUser)dataItem;

            if (mu.IsOnline)
                return "~/Styles/Images/icon_useronline.png";
            
            return "~/Styles/Images/icon_useroffline.png";
        }

        public static string GetUserTypeDescription(object dataItem)
        {
            var keyValuePair = (KeyValuePair<string, int>)dataItem;
            var userType = (UserTypes)Enum.Parse(typeof(UserTypes), keyValuePair.Key);

            return userType.GetDescription();
        }

        public static string GetUserTypeDescriptionAndTitle(object dataItem)
        {
            const string retHtml = "{0} (<strong>{1}</strong>)"; 
            var keyValuePair = (KeyValuePair<string, int>)dataItem;
            var userType = (UserTypes)Enum.Parse(typeof(UserTypes), keyValuePair.Key);

            return string.Format(retHtml, userType.GetDescription(), userType.GetTitle());
        }

        public static string GetUserTypesNeededAsCsvAndSetDescriptionsFromRepeater(IUser user, Repeater repUserTypes)
        {
            if (repUserTypes == null) return string.Empty;

            var sb = new StringBuilder();

            foreach (RepeaterItem item in repUserTypes.Items)
            {
                var txtUserTypeDescription = (TextBox)item.FindControl("txtUserTypeDescription");
                var chkUserType = (CheckBox)item.FindControl("chkUserType");
                var hiddenUserType = (HiddenField)item.FindControl("hiddenUserType");

                if (txtUserTypeDescription == null || chkUserType == null || hiddenUserType == null)
                    return string.Empty;

                var userType = (UserTypes)Enum.Parse(typeof(UserTypes), hiddenUserType.Value);
                switch (userType)
                {
                    case UserTypes.Businessman:
                        user.DescBusinessman = txtUserTypeDescription.Text;
                        break;
                    case UserTypes.Entrepreneur:
                        user.DescEntrepreneur = txtUserTypeDescription.Text;
                        break;
                    case UserTypes.Financing:
                        user.DescFinancing = txtUserTypeDescription.Text;
                        break;
                    case UserTypes.Innovator:
                        user.DescInnovator = txtUserTypeDescription.Text;
                        break;
                    case UserTypes.Investor:
                        user.DescInvestor = txtUserTypeDescription.Text;
                        break;
                    case UserTypes.Retiring:
                        user.DescRetiring = txtUserTypeDescription.Text;
                        break;
                    default:
                        throw new Exception("Invalid user type");
                }

                if (chkUserType.Checked)
                    sb.Append(hiddenUserType.Value + ", ");
            }

            return sb.ToString().Trim().TrimEnd(new[] { ',' });
        }

        public static string FormatHeading(string displayName, string formattedDate)
        {
            return string.Format("<strong>{0}</strong> {1}", displayName, formattedDate);
        }
    }
}