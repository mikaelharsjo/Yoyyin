using System;
using System.Web.Security;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;
using Yoyyin.PresentationModel;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web
{
    public partial class Home : System.Web.UI.Page
    {
        public IUser CurrentUser;
        public string CurrentEmail { get; set; }
        public IMessagesService MessagesService { get; set; }
        public IMessagePresenter MessagePresenter { get; set; }
        public IRepository<Bookmark> BookmarkRepository { get; set; }
        public IBookmarkPresenter BookmarkPresenter { get; set; }
        public ICurrentUser Current { get; set; }
        public IUserService UserService { get; set; }
        

        private MembershipUser _currentMembershipUser;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (WebHelpers.IsLoggedIn())
            {
                _currentMembershipUser = Membership.GetUser();
                //currentUserId = new Guid(_currentMembershipUser.ProviderUserKey.ToString());
                CurrentUser = UserService.GetCurrentUser();
                CurrentEmail = _currentMembershipUser.Email;
            }
            else
                Server.Transfer("~/Default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lstMessages.DataSource = MessagePresenter.Presentate(MessagesService.GetInBoxMessages(Current.UserId));
            lstMessages.DataBind();

            lstMessagesSent.DataSource = MessagePresenter.Presentate(MessagesService.GetOutBoxMessages(Current.UserId));
            lstMessagesSent.DataBind();

            lstBookmarks.DataSource =
                BookmarkPresenter.Presentate(BookmarkRepository.Find(b => b.UserId == CurrentUser.UserId));
            lstBookmarks.DataBind();
        }
    }
}