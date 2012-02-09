using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Autofac;
using Autofac.Integration.Web;
using Yoyyin.Domain.Services;
using Yoyyin.PresentationModel;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web
{
    public partial class SiteMaster : MasterPage
    {
        public IUserService UserService { get; set; }
        public IUserPresenter UserPresenter { get; set; }

        public Literal LitLoggedInInfo
        {
            get { return litLoggedInInfo; }
        }

        public void ShowToolbar()
        {
            toolbar.Visible = true;
        }

        public string OnKeyPress { get; set; }

        public LoginStatus LoginStatus
        {
            get { return loginStatus; }
        }

        public const string LoggedInInfo = "<img src='Styles/Images/icon_useronline.png' alt='online' /> <strong>{0}</strong>";
        public const string CountTxt = "Just nu {0} medlemmar";
        protected override void OnInit(EventArgs e)
        {
            // autofac doesn´t support masterpages automagically
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            cp.RequestLifetime.InjectProperties(this);

            base.OnInit(e);
            
            if (WebHelpers.IsLoggedIn())
            {
                loginLink.Visible = false;
                lnkLogin.Visible = false;
                spnRegister.Visible = false;
                spnDocuments.Visible = false;
                spnForum.Visible = false;
                spnLinks.Visible = false;
                hiddenLoggedIn.Value = "true";
                litLoggedInInfo.Text = string.Format(LoggedInInfo, WebHelpers.GetCurrentUserName());
                body.Attributes.Add("class", "isLoggedIn");
            }
            else
            {
                toolbar.Visible = false;
                divSeparator.InnerHtml = "&nbsp;";
                hiddenLoggedIn.Value = "false";
            }

            login.LoginError += login_LoginError;
            login.LoggedIn += LoginLoggedIn;
            passwordRecovery.UserLookupError += passwordRecovery_UserLookupError;
            passwordRecovery.SendingMail += passwordRecovery_SendingMail;

            var newMembers = GetNewestMembersFromCacheOrDb();
            lstNewest.DataSource = UserPresenter.Presentate(newMembers.Select(memuser => new Guid(memuser.ProviderUserKey.ToString())));
            lstNewest.DataBind();
            
            lstPopular.DataSource = UserPresenter.Presentate(UserService.GetUserIDsWithMostVisits());
            lstPopular.DataBind();
            litCount.Text = string.Format(CountTxt, UserService.GetNumberOfUsers());
        }

        void LoginLoggedIn(object sender, EventArgs e)
        {
            if (Request.Url.LocalPath.ToLower().Contains("default.aspx"))
                Response.Redirect("~/Home.aspx");
        }

        private static IEnumerable<MembershipUser> GetNewestMembersFromCacheOrDb()
        {
            IEnumerable<MembershipUser> newMembers;
            if (HttpContext.Current.Cache["NewestMembers"] != null)
                newMembers = HttpContext.Current.Cache["NewestMembers"] as IEnumerable<MembershipUser>;
            else
            {
                var memUsers = from MembershipUser user in Membership.GetAllUsers() select user;
                newMembers = memUsers.OrderByDescending(x => x.CreationDate).Take(5);
                HttpContext.Current.Cache.Insert("NewestMembers", newMembers, null, DateTime.Now.AddHours(24), Cache.NoSlidingExpiration);
            }
            return newMembers;
        }

        void passwordRecovery_SendingMail(object sender, MailMessageEventArgs e)
        {
            ShowPasswordPop();
        }

        void passwordRecovery_UserLookupError(object sender, EventArgs e)
        {
            ShowPasswordPop();
        }

        void ShowPasswordPop()
        {
            const string script = "$(document).ready(function () { $('#divPasswordRecovery').show(); $('#popBg').show(); $('#divPasswordRecovery').center(); $('#popBg').click(function () { $('#divPasswordRecovery').hide(); $('#popBg').hide(); });});";
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", script, true);
        }

        void login_LoginError(object sender, EventArgs e)
        {
            const string script = "$(document).ready(function () { $('#divLogin').show(); $('#popBg').show(); $('#divLogin').center(); $('#popBg').click(function () { $('#divLogin').hide(); $('#popBg').hide(); });});";
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", script, true);
        }
    }
}
