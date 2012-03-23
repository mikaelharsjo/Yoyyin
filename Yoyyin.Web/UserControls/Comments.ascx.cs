using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Yoyyin.Data;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;
using Yoyyin.PresentationModel;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web.UserControls
{    
    public partial class Comments : UserControlWithDependenciesInjected
    {
        const string CommentsEmpty = "Bli först med att kommentera denna affärsidé/verksamhet";
        const string CommentsNotEmpty = "Det finns {0} kommentarer";

        public Guid UserId { get; set; }
        public int TextAreaWidth { get; set; }

        public ICommentsService CommentsService { get; set; }
        public IUserService UserService { get; set; }
        public ICurrentUser CurrentUser { get; set; }
        public ICommentPresenter CommentPresenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //var user = UserService.GetUser(UserId);

            if (!WebHelpers.IsLoggedIn())
                divNewComment.Visible = false;

            var comments = CommentsService.GetComments(UserId);
            var commentsSorted = SortComments(comments.ToList());
            int count = comments.Count();
            if (count > 0)
            {
                lstComments.DataSource = CommentPresenter.Presentate(comments); //from c in commentsSorted select new { GetMemberUrl = GetMemberUrl(c), CommentUserID = c.CommentID, UserName = c.User.GetDisplayName(), DeleteVisible = DeleteVisible(c) };
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

        private static IList<UserComments> SortComments(IList<UserComments> comments)
        {
            var commentsSorted = new List<UserComments>();
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

        //public string GetStyle(object item)
        //{   
        //    var comment = (Comment)item;
        //    if (comment.CommentCommentID != null)
        //        return "padding-left: 20px;";

        //    return string.Empty;
        //}

        protected string GetMemberUrl(object item)
        {
            var comment = (UserComments)item;
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