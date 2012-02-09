using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web.UserControls
{    
    public partial class Comments : System.Web.UI.UserControl
    {
        const string CommentsEmpty = "Bli först med att kommentera denna affärsidé/verksamhet";
        const string CommentsNotEmpty = "Det finns {0} kommentarer";

        public Guid UserId { get; set; }
        public Guid CurrentUserID { get; set; }
        public int TextAreaWidth { get; set; }

        public ICommentsService CommentsService { get; set; }
        public IUserService UserService { get; set; }   

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserService.GetUser(UserId);
            CurrentUserID = Current.UserID;

            if (!WebHelpers.IsLoggedIn())
                divNewComment.Visible = false;

            var comments = user.GetComments();
            var commentsSorted = SortComments(comments);
            int count = comments.Count();
            if (count > 0)
            {
                lstComments.DataSource = from c in commentsSorted select new { GetMemberUrl = GetMemberUrl(c), CommentUserID = c.CommentID, UserName = c.User.GetDisplayName(), DeleteVisible = DeleteVisible(c) };
                lstComments.DataBind();

                litComments.Text = string.Format(CommentsNotEmpty, count.ToString());
                if (count == 1)
                    litComments.Text = litComments.Text.Substring(0, litComments.Text.Length - 2);
            }
            else
            {
                litComments.Text = CommentsEmpty;
            }
        }

        private static List<Comment> SortComments(List<Comment> comments)
        {
            var commentsSorted = new List<Comment>();
            foreach (var comment in comments)
            {
                if (comment.CommentCommentID != null)
                    commentsSorted.Insert(comments.IndexOf(comments.First(x => x.CommentID == comment.CommentCommentID)) + 1, comment);
                else
                    commentsSorted.Add(comment);
            }
            return commentsSorted;
        }

        #region Data Bind

        public string GetStyle(object item)
        {   
            var comment = (Comment)item;
            if (comment.CommentCommentID != null)
                return "padding-left: 20px;";

            return string.Empty;
        }

        protected bool DeleteVisible(object item)
        {
            MembershipUser mu = Membership.GetUser();
            if (mu == null)
                return false;

            var comment = (Comment)item;
            
            // delete allowed
            if (comment.User.UserId == Current.UserID) // || comment == Current.UserID)
                return true;

            return false;
        }

        protected string GetMemberUrl(object item)
        {
            var comment = (Comment)item;
            string urlStart = "Member.aspx";

            if (comment.User.UserId == Current.UserID)
                return urlStart;
            else
                return urlStart + "?UserID=" + comment.User.UserId;
        }

        #endregion

        protected string GetSendCommentScript(string txtVal)
        {
            string sendMailScript = "SaveComment(\"{0}\", \"{1}\", {2});";
            return string.Format(sendMailScript, Membership.GetUser().ProviderUserKey, UserId, txtVal);
        }
    }
}