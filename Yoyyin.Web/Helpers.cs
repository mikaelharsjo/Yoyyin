using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using Zitac.Trinity.Business.Extensions;

public enum UserTypes { entrepreneur, innovator, investor, financing, retiring, businessman }

/// <summary>
/// Summary description for Helpers
/// </summary>
public class Helpers
{
    const string MAIL_SUBJECT = "Meddelande via Yoyyin från {0}";
    const string MEMBER_URL = "Member.aspx?UserID={0}";
    const string FORUM_POST_URL = "/Forum.aspx?Post={0}";
    public const string MAIL_FOOTER = "<br/>För att läsa/svara på detta gå in på <a href='http://yoyyin.com{0}' target='_blank'>yoyyin.com</a><br/><br/>Hälsningar Yoyyin";
    const string MAIL_STYLES = "<style type='text/css'>body {font-family: Trebuchet, Calibri, Arial, Sans-Serif; font-size: 20px; line-height: 25px; color: #444444;}</style>";
    public const int FORUM_BOARD_ID = 4;
    public const int FORUM_GUEST_ID = 13009;
    public const string FACEBOOK_IMAGEURL_SMALL = "https://graph.facebook.com/{0}/picture";
    public const string FACEBOOK_IMAGEURL_LARGE = "https://graph.facebook.com/{0}/picture?type=large";
    public const string MAIL_FOOTER2 = "<br/><br/>Hälsningar Anders, Peter & Mikael på Yoyyin";
        
    public Helpers()
    {
    }

    /// <summary>/// Renders a user control into a string/// </summary>/// 
    /// <param name="page">Instance of the page that is hosting the control</param>/// 
    /// <param name="userControlVirtualPath"></param>/// <param name="includePostbackControls">
    /// If false renders using RenderControl, otherwise uses Server.Execute() constructing a new form.
    /// </param>/// <param name="data">Optional Data parameter that can be passed to the User Control 
    /// IF the user control has a Data property.</param>/// <returns></returns>
    public static string RenderUserControl(string userControlVirtualPath, bool includePostbackControls, Dictionary<string, object> parameters, bool addScriptmanager)
    {
        // const string STR_NoUserControlDataProperty = "Passed a Data parameter to RenderUserControl, but the user control has no public Data property.";
        const string STR_BeginRenderControlBlock = "<!-- BEGIN RENDERCONTROL BLOCK -->";
        const string STR_EndRenderControlBlock = "<!-- End RENDERCONTROL BLOCK -->";
        StringWriter tw = new StringWriter();
        Control control = null;
        if (!includePostbackControls)
        {        // *** Simple rendering works if no post back controls are used        
            System.Web.UI.Page curPage = (System.Web.UI.Page)HttpContext.Current.Handler;
            control = curPage.LoadControl(userControlVirtualPath);

            foreach (KeyValuePair<string, object> kvp in parameters)
            {
                SetValue(control, kvp.Key, kvp.Value);
            }
            return RenderControl(control);
        }
        // *** Create a page and form so that postback controls work              
        System.Web.UI.Page page = new System.Web.UI.Page();
        page.EnableViewState = false;
        // *** IMPORTANT: Control must be loaded of this NEW page context or call will fail  
        ScriptManager sc = new ScriptManager();

        control = page.LoadControl(userControlVirtualPath);
        foreach (KeyValuePair<string, object> kvp in parameters)
        {
            SetValue(control, kvp.Key, kvp.Value);
        }

        HtmlForm form = new HtmlForm();
        form.ID = "__t";
        page.Controls.Add(form);
        if (addScriptmanager)
            form.Controls.Add(sc);
        form.Controls.Add(new LiteralControl(STR_BeginRenderControlBlock));
        form.Controls.Add(control);
        form.Controls.Add(new LiteralControl(STR_EndRenderControlBlock));

        HttpContext.Current.Server.Execute(page, tw, true);

        string Html = tw.ToString();
        // *** Strip out form and ViewState, Event Validation etc.    
        Html = ExtractString(Html, STR_BeginRenderControlBlock, STR_EndRenderControlBlock);
        return Html;
    }

    /// <summary>/// Renders a user control into a string/// </summary>/// 
    /// <param name="page">Instance of the page that is hosting the control</param>/// 
    /// <param name="userControlVirtualPath"></param>/// <param name="includePostbackControls">
    /// If false renders using RenderControl, otherwise uses Server.Execute() constructing a new form.
    /// </param>/// <param name="data">Optional Data parameter that can be passed to the User Control 
    /// IF the user control has a Data property.</param>/// <returns></returns>
    public static string RenderUserControl(Control control, bool includePostbackControls, Dictionary<string, object> parameters, bool addScriptmanager)
    {
        // const string STR_NoUserControlDataProperty = "Passed a Data parameter to RenderUserControl, but the user control has no public Data property.";
        const string STR_BeginRenderControlBlock = "<!-- BEGIN RENDERCONTROL BLOCK -->";
        const string STR_EndRenderControlBlock = "<!-- End RENDERCONTROL BLOCK -->";
        StringWriter tw = new StringWriter();
        if (!includePostbackControls)
        {        // *** Simple rendering works if no post back controls are used        
            System.Web.UI.Page curPage = (System.Web.UI.Page)HttpContext.Current.Handler;

            foreach (KeyValuePair<string, object> kvp in parameters)
            {
                SetValue(control, kvp.Key, kvp.Value);
            }
            return RenderControl(control);
        }
        // *** Create a page and form so that postback controls work              
        System.Web.UI.Page page = new System.Web.UI.Page();
        page.EnableViewState = false;
        // *** IMPORTANT: Control must be loaded of this NEW page context or call will fail  
        ScriptManager sc = new ScriptManager();

        foreach (KeyValuePair<string, object> kvp in parameters)
        {
            SetValue(control, kvp.Key, kvp.Value);
        }

        HtmlForm form = new HtmlForm();
        form.ID = "__t";
        page.Controls.Add(form);
        if (addScriptmanager)
            form.Controls.Add(sc);
        form.Controls.Add(new LiteralControl(STR_BeginRenderControlBlock));
        form.Controls.Add(control);
        form.Controls.Add(new LiteralControl(STR_EndRenderControlBlock));

        HttpContext.Current.Server.Execute(page, tw, true);

        string Html = tw.ToString();
        // *** Strip out form and ViewState, Event Validation etc.    
        Html = ExtractString(Html, STR_BeginRenderControlBlock, STR_EndRenderControlBlock);
        return Html;
    }

    public static string RenderControl(Control control)
    {
        StringWriter tw = new StringWriter();
        // *** Simple rendering - just write the control to the text writer    
        // *** works well for single controls without containers    
        Html32TextWriter writer = new Html32TextWriter(tw);
        control.RenderControl(writer); 
        writer.Close();
        writer.Dispose();
        string retVal = tw.ToString();
        tw.Dispose();
        return retVal;
    }



    static void SetValue(Control control, string propertyName, object propertyValue)
    {

        Type viewControlType = control.GetType();
        PropertyInfo property =
           viewControlType.GetProperty(propertyName);

        if (property != null)
        {
            property.SetValue(control, propertyValue, null);
        }
        else
        {
            throw new Exception(string.Format(
               "UserControl: {0} does not have a public {1} property.",
               viewControlType.Name, propertyName));
        }
    }

    public static string GetOnlineImageUrl2(object userId)
    {
        if (userId == null)
            return "~/Styles/Images/empty.gif";
        else
            return Helpers.GetOnlineImageUrl(Membership.GetUser(new Guid(userId.ToString())));
    }

    public static string ExtractString(string str, string start, string end)
    {
        int startPos = str.IndexOf(start) + start.Length;
        int endPos = str.IndexOf(end) - startPos;
        return str.Substring(startPos, endPos);
    }

    public static string TruncateText(string OriginalText, int MaxCharacters)
    {
        if (string.IsNullOrEmpty(OriginalText))
            return string.Empty;

        string stopChars = " .!?";

        if (OriginalText.Length > MaxCharacters)
        {
            string stringToReturn = OriginalText.Substring(0, MaxCharacters);

            while (!stopChars.Contains(stringToReturn.Substring
               (stringToReturn.Length - 1)) && stringToReturn.Length > 0)
            {
                stringToReturn = stringToReturn.Substring(0,
                   stringToReturn.Length - 1);
            }

            if (stringToReturn.Length == 0)
                stringToReturn = OriginalText.Substring(MaxCharacters);

            stringToReturn = stringToReturn.Trim();

            if (!stopChars.Contains(stringToReturn.Substring
               (stringToReturn.Length - 1)))
            {
                stringToReturn += "...";
            }

            return stringToReturn;
        }
        else
        {
            return OriginalText;
        }
    }

    public static string GetUserUrl(object userId)
    {
        if (userId == null)
            return "#";
        else
            return string.Format(MEMBER_URL, userId.ToString());
    }

    public static string GetUserName(object userId)
    {
        try
        {
            if (userId == null)
                return "Inte inloggad";

            using (yoyyin.com.YoyyinEntities1 entities = new yoyyin.com.YoyyinEntities1())
            {
                Guid gUserId = new Guid(userId.ToString());
                yoyyin.com.User user = entities.User.FirstOrDefault(x => x.UserId == gUserId);
                if (!string.IsNullOrEmpty(user.Alias))
                    return user.Alias;
                
                if (user.Name.Length > 0)
                    return user.Name;
                else
                    return "Inte angivit";
            }
        }
        catch { return string.Empty; }
    }

    public static string GetEmail(object userID)
    {
        MembershipUser mu = Membership.GetUser();
        if (mu == null)
            return string.Empty;
        else
            return mu.Email;
    }

    public static Guid CurrentUserID()
    {
        MembershipUser mu = Membership.GetUser();
        if (mu != null)
        {
            return new Guid(mu.ProviderUserKey.ToString());
        }
        else
            return Guid.Empty;
    }

    public static bool IsLoggedIn()
    {
        return CurrentUserID() != Guid.Empty;
    }

    public static Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
    {
        Bitmap result = new Bitmap(nWidth, nHeight);
        using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
            g.DrawImage(b, 0, 0, nWidth, nHeight);

        return result;
    }

    public static void SendYoyyinMail(string fromUserId, string toUserId, string message)
    {
        using (yoyyin.com.YoyyinEntities1 entities = new yoyyin.com.YoyyinEntities1())
        {
            yoyyin.com.UserMessages userMessage = entities.CreateObject<yoyyin.com.UserMessages>();

            entities.UserMessages.AddObject(userMessage);

            userMessage.FromMessage = message.TruncateText(400);
            userMessage.FromUserId = new Guid(fromUserId);
            userMessage.ToUserId = new Guid(toUserId);
            userMessage.TimeStamp = DateTime.Now;

            entities.SaveChanges();

            yoyyin.com.User userFrom = entities.User.First(x => x.UserId == new Guid(fromUserId)); 
            yoyyin.com.User userTo = entities.User.First(x => x.UserId == new Guid(toUserId));

            string footer = string.Format(MAIL_FOOTER, "/Home.aspx");
            SendMail(message, string.Format(MAIL_SUBJECT, userFrom.Name), Membership.GetUser(userFrom.UserId).Email, Membership.GetUser(userTo.UserId).Email, footer); 
        }        
    }

    public static void SendErrorMail(string message)
    {
        SendMail(message, "Fel på Yoyyin", "", "mikael@zitac.se", string.Empty);
    }

    public static void SendMail(string body, string subject, string replyTo, string to, string footer)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("noreply@zitac.se");
            if (replyTo.Length > 0)
                mail.ReplyToList.Add(new MailAddress(replyTo));

            if (string.IsNullOrEmpty(to))
                mail.To.Add(new MailAddress("mikael@zitac.se"));
            else
                mail.To.Add(new MailAddress(to));

            mail.IsBodyHtml = true;
            mail.Subject = subject;

            mail.Body = MAIL_STYLES + "<body>" + body + "<br/>" + footer + "</body>";
            //mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString((System.Text.RegularExpressions.Regex.Replace(body, @"<(.|\n)*?>", string.Empty)), null, "text/plain"));
            //mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(body, null, "text/html"));

            SmtpClient server = new SmtpClient();
            server.Send(mail);
        }
        catch (Exception ex)
        {
            Helpers.SendErrorMail(ex.Message);
        }
    }

    public static string GetAvatarHtml(yoyyin.com.User user)
    {
        string imagePath = "~/ImageCache/" + user.UserId.ToString() + ".jpeg";
        string image = string.Empty;

        if (user.Image != null)
        {
            if (user.Image.Length > 0)
            {
                if (!File.Exists(HttpContext.Current.Server.MapPath(imagePath)))
                {
                    byte[] data = user.Image;
                    Int32 offset = 0;
                    System.IO.MemoryStream mstream = new System.IO.MemoryStream();
                    mstream.Write(data, offset, data.Length - offset);
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mstream);
                    float scaleFactor = (float)73.0 / (float)bmp.Width;
                    bmp = Helpers.ResizeBitmap(bmp, 73, (int)(bmp.Height * scaleFactor));
                    bmp.Save(HttpContext.Current.Server.MapPath(imagePath), System.Drawing.Imaging.ImageFormat.Jpeg);
                    mstream.Close();
                }
            }
            else
                imagePath = "~/Styles/Images/noImage.png";
        }
        else
            imagePath = "~/Styles/Images/noImage.png";

        image = "<img src=" + VirtualPathUtility.ToAbsolute(imagePath) + " />";
        return image;
    }

    public static void DeleteUser(Guid userId)
    {
        string userName = string.Empty;
        try
        {
            userName = Membership.GetUser(userId).UserName;   // Helpers.GetUserName(userId.ToString());
            using (yoyyin.com.YoyyinEntities1 entities = new yoyyin.com.YoyyinEntities1())
            {
                //entities.UserMessages.Select(x => x.FromUserId == userId)
                var messages = from x in entities.UserMessages where x.FromUserId == userId select x;
                foreach (yoyyin.com.UserMessages message in messages)
                    entities.DeleteObject(message);

                var messages2 = from x in entities.UserMessages where x.ToUserId == userId select x;
                //yoyyin.com.UserMessages userMessages2 = entities.UserMessages.FirstOrDefault(x => x.ToUserId == userId);
                foreach (yoyyin.com.UserMessages message in messages2)
                    entities.DeleteObject(message);

                var comments = from x in entities.UserComments where x.CommentUserId == userId select x;
                //yoyyin.com.UserComments comments = entities.UserComments.FirstOrDefault(x => x.CommentUserId == userId);
                foreach (yoyyin.com.UserComments comment in comments)
                    entities.DeleteObject(comment);

                //yoyyin.com.UserComments comments2 = entities.UserComments.FirstOrDefault(x => x.UserId == userId);
                comments = from x in entities.UserComments where x.UserId == userId select x;
                foreach (yoyyin.com.UserComments comment in comments)
                    entities.DeleteObject(comment);

                //yoyyin.com.UserVisits visits2 = entities.UserVisits.FirstOrDefault(x => x.UserId == userId);
                var visits = from x in entities.UserVisits where x.UserId == userId select x;
                foreach (yoyyin.com.UserVisits visit in visits)
                    entities.DeleteObject(visit);

                visits = from x in entities.UserVisits where x.VisitingUserId == userId select x;
                foreach (yoyyin.com.UserVisits visit in visits)
                    entities.DeleteObject(visit);

                var bookmarks = from x in entities.UserBookmarks where x.UserId == userId select x;
                foreach (yoyyin.com.UserBookmarks bookmark in bookmarks)
                    entities.DeleteObject(bookmark);

                bookmarks = from x in entities.UserBookmarks where x.BookmarkedUserID == userId select x;
                foreach (yoyyin.com.UserBookmarks bookmark in bookmarks)
                    entities.DeleteObject(bookmark);

                entities.DeleteObject(entities.User.FirstOrDefault(x => x.UserId == userId));

                entities.SaveChanges();
            }

            Membership.DeleteUser(userName, true);
        }
        catch (Exception ex)
        {
            SendErrorMail(ex.Message);
        }
    }

    public static void DeleteAllUsers()
    {
        using (yoyyin.com.YoyyinEntities1 entities = new yoyyin.com.YoyyinEntities1())
        {
            foreach (yoyyin.com.User user in entities.User)
            {
                //if (user.Name == "Mikael Härsjö")
                    entities.DeleteObject(user);
            }

            foreach (yoyyin.com.UserMessages um in entities.UserMessages)
                entities.DeleteObject(um);

            try
            {
                entities.SaveChanges();
            }
            catch (UpdateException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        foreach (MembershipUser u in Membership.GetAllUsers())
        {
            //if (u.UserName.Contains("mikael"))
                Membership.DeleteUser(u.UserName, true);
        }
    }

    public static bool HasFacebook(object dataItem)
    {
        using (yoyyin.com.YoyyinEntities1 entities = new yoyyin.com.YoyyinEntities1())
        {
            yoyyin.com.User user = new yoyyin.com.User();
            if (dataItem is yoyyin.com.User)
                user = (yoyyin.com.User)dataItem;
            else if (dataItem is yoyyin.com.UserComments)
            {
                yoyyin.com.UserComments comment = (yoyyin.com.UserComments)dataItem;

                user = entities.User.FirstOrDefault(x => x.UserId == comment.CommentUserId);

            }
            else if (dataItem is Guid)
            {
                user = entities.User.FirstOrDefault(x => x.UserId == (Guid)dataItem);
            }
            if (string.IsNullOrEmpty(user.FacebookID) || user.Image != null)
                return false;
            else
                return true;
        }
    }

    public static string GetFbUrl(object dataItem)
    {
        using (yoyyin.com.YoyyinEntities1 entities = new yoyyin.com.YoyyinEntities1())
        {
            yoyyin.com.User user = new yoyyin.com.User();
            if (dataItem is yoyyin.com.User)
                user = (yoyyin.com.User)dataItem;
            else if (dataItem is yoyyin.com.UserComments)
            {
                yoyyin.com.UserComments comment = (yoyyin.com.UserComments)dataItem;
                user = entities.User.FirstOrDefault(x => x.UserId == comment.CommentUserId);
            }
            else if (dataItem is Guid)
            {
                user = entities.User.FirstOrDefault(x => x.UserId == (Guid)dataItem);
            }

            if (!string.IsNullOrEmpty(user.FacebookID) && user.Image == null)
                return string.Format(Helpers.FACEBOOK_IMAGEURL_SMALL, user.FacebookID);
            else
                return string.Empty;
        }
    }

    public static string ShowFacebookImage(yoyyin.com.User user)
    {
        if (user == null)
            return string.Empty;

        if (string.IsNullOrEmpty(user.FacebookID) || user.Image != null)
            return "display: none;";
        else
            return string.Empty;
    }

    public static string HasFacebookImage(yoyyin.com.User user)
    {
        if (string.IsNullOrEmpty(user.FacebookID) || user.Image != null)
            return "false";
        else
            return "true";
    }

    public static string GetFbUrl(yoyyin.com.User user)
    {
        if (user == null)
            return string.Empty;

        if (!string.IsNullOrEmpty(user.FacebookID) && user.Image == null)
            return string.Format(Helpers.FACEBOOK_IMAGEURL_LARGE, user.FacebookID);
        else
            return string.Empty;
    }

    public static string GetClass()
    {
        if (Membership.GetUser() == null)
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
            date = System.Convert.ToDateTime(drv.Row["LastPosted"]);
        }
        else
        {
            PropertyInfo pInfo = dataItem.GetType().GetProperties().First(x => x.Name == "TimeStamp");
            date = (DateTime)pInfo.GetValue(dataItem, null);
        }

        if (shortDate)
            return date.ToShortDateString();
        else
            return date.ZFormat();
    }

    public static string GetOnlineImageUrl(object dataItem)
    {
        MembershipUser mu = (MembershipUser)dataItem;

        if (mu.IsOnline)
            return "~/Styles/Images/icon_useronline.png";
        else
            return "~/Styles/Images/icon_useroffline.png";
    }

    #region Forum Helpers

    public static string GetForumPostUrl(object dataItem)
    {
        DataRowView rv = (DataRowView)dataItem;
        return string.Format(FORUM_POST_URL, rv.Row["LastmessageID"]);
    }

    public static string GetUserNameFromForumUserName(string forumUserName)
    {
        try
        {
            return GetUserName(Membership.GetUser(forumUserName).ProviderUserKey);
        }
        catch (Exception ex)
        {
            //Helpers.SendErrorMail(ex.Message);
            return "gäst";
        }
    }
    
    #endregion
}