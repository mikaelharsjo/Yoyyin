using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Caching;
using System.Web.UI.HtmlControls;
using System.Text;
using Yoyyin.Domain;
using Yoyyin.Domain.Enumerations;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.Users;
using Yoyyin.PresentationModel;
using Yoyyin.Web.Helpers;
using Yoyyin.Web.UserControls;

namespace Yoyyin.Web
{
    public partial class Member : System.Web.UI.Page
    {
        const string Http = "http://";
        const string SegmentHtml = "<div class='span-24 last sni{2} segment marginBottom'><div class='span-6'><div class='paddingSmall'>{0}</div></div><div class='span-12'><div class='paddingSmall'>{3} affärsidéer inom {1}</div></div><div class='span-6 last textAlignRight'><div class='paddingSmall'><a href='Member.aspx?UserID={4}'>Nästa affärsidé &raquo;</a></div></div></div><br /><br /><br />";
        const string GenericKeywords = ",affärspartner,affärsidé,startup,affärskollega,entreprenör,företagare,partner,hitta,söker,sökes";
        // TODO: remove CurrentUser for CurrentUserPresentation
        public static IUser CurrentUser { get; set; } 
        public UserPresentation CurrentUserPresentation { get; set; }
        public IUserService UserService { get; set; }
        public IVisitsService VisitsService { get; set; }
        public ISniHeadService SniHeadService { get; set; }
        public IUserPresenter UserPresenter { get; set; }
        public IVisitPresenter VisitPresenter { get; set; }
        public NewestMembersHelper NewestMembersHelper { get; set; }
        
        public Guid UserIDOfUserBeingViewed = Guid.Empty;
        public Guid VisitingUserId { get; set; }
        bool _selfVisit;

        #region Event Handlers

        protected override void OnInit(EventArgs e)
        {
            changePassword.ChangedPassword += changePassword_ChangedPassword;
            base.OnInit(e);
            
            if (IsSelfVisit()) 
            {
                _selfVisit = true;
                divSelfVisit.Visible = true;
                
                if (!WebHelpers.IsLoggedIn())
                    Response.Redirect("~/Default.aspx");

                UserIDOfUserBeingViewed = Current.UserID;

                ShowControlInLoginView("divOwnDescriptionAndTitle");
                HideControlInLoginView("divContact");
                ShowControlInLoginView("divPublicLink");

                ShowWelcomeWindowOnFirstVisit();
            }
            else // real visit
            {
                UserIDOfUserBeingViewed = Request["UserID"] != null ? new Guid(Request["UserID"]) : new Guid(Page.RouteData.Values["UserID"].ToString());

                VisitingUserId = Current.UserID;

                HideControlInLoginView("divMembers");
                HideControlInLoginView("divSearch");
                HideControlInLoginView("divEdit");
            }

            CurrentUser = UserService.GetUser(UserIDOfUserBeingViewed);
            CurrentUserPresentation = UserPresenter.Presentate(CurrentUser);

            if (!_selfVisit)
            {
                if (WebHelpers.IsLoggedIn())
                    VisitsService.LogMemberVisit(CurrentUser.UserId, UserIDOfUserBeingViewed);
                else
                    VisitsService.LogAnonymousVisit(UserIDOfUserBeingViewed);
            }

            SetMetaInfo();

            SetGeneratedImageParams();         
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HideAdressAndEmailAccordingToUserSettings();

                SetCVLink();

                if (WebHelpers.IsLoggedIn())
                {
                    var userPosts = (UserPosts)loginView.FindControl("userPosts");
                    userPosts.UserId = CurrentUser.UserId;
                    
                    DataBindNewestMembers();
                    DataBindVisits();
                }
            }
        }

        private void SetGeneratedImageParams()
        {
            var userImageAnonymous = (UserImage)loginView.FindControl("userImageAnonymous");
            var userImageLoggedIn = (UserImage)loginView.FindControl("userImageLoggedIn");
            if (userImageAnonymous != null)
                userImageAnonymous.User = CurrentUser;
            if (userImageLoggedIn != null)
                userImageLoggedIn.User = CurrentUser;
        }

        private void HideControlInLoginView(string controlID)
        {
            ToggleControlInLoginView(controlID, false);
        }

        private void ShowControlInLoginView(string controlID)
        {
            ToggleControlInLoginView(controlID, true);
        }

        private void ToggleControlInLoginView(string controlID, bool visibility)
        {
            var controlInLoginView = (HtmlGenericControl)loginView.FindControl(controlID);
            if (controlInLoginView != null)
                controlInLoginView.Visible = visibility;
        }

        private void SetMetaInfo()
        {
            Page.Title = CurrentUser.BusinessTitle;
            Page.MetaDescription = "Affärspartnerns affärsidé:" + CurrentUser.BusinessDescription;
            Page.MetaKeywords = CurrentUser.SearchWords + GenericKeywords;
        }

        private void ShowWelcomeWindowOnFirstVisit()
        {
            if (Request["FirstTime"] != null)
            {
                if (Request["FirstTime"] == "1")
                {
                    string script = "$(document).ready(function () { $('#divWelcome').show(); $('#divWelcome').center(); $('#popBg').show(); $('#popBg').click(function () { $('#divWelcome').hide(); $('#popBg').hide(); });});";
                    litJavaScript.Text = script;                    
                }
            }
        }

        private bool IsSelfVisit()
        {
            return Request["UserID"] == null && Page.RouteData.Values["UserID"] == null;
        }

        void changePassword_ChangedPassword(object sender, EventArgs e)
        {
            Response.Redirect("Member.aspx");
        }

        private void DataBindVisits()
        {
            var lstVisits = (ListView)loginView.FindControl("lstVisits");
            if (lstVisits != null)
            {
                lstVisits.DataSource = VisitPresenter.Presentate(VisitsService.GetVisits(CurrentUser.UserId));
                lstVisits.DataBind();
            }
        }

        private void DataBindNewestMembers()
        {
            var lstNewest = (ListView)loginView.FindControl("lstNewest");
            if (lstNewest != null)
            {
                var newMembers = NewestMembersHelper.GetNewestMembersFromCacheOrDb();
                lstNewest.DataSource = UserPresenter.Presentate(newMembers.Select(memuser => new Guid(memuser.ProviderUserKey.ToString())));
                lstNewest.DataBind();
            }
        }

        private void SetCVLink()
        {
            var lnkCV = (HyperLink)loginView.FindControl("lnkCV");
            if (lnkCV != null)
            {
                if (!string.IsNullOrEmpty(CurrentUser.CVFileName))
                    lnkCV.NavigateUrl = "~/Upload/" + CurrentUser.CVFileName;
                else
                    lnkCV.Visible = false;
            }
        }

        private void HideAdressAndEmailAccordingToUserSettings()
        {
            var divStreet = (HtmlGenericControl)loginView.FindControl("divStreet");
            var divEmail = (HtmlGenericControl)loginView.FindControl("divEmail");
            if (!CurrentUser.ShowAddress && divStreet != null)
                divStreet.Visible = false;
            if (!CurrentUser.ShowEmail && divEmail != null)
                divEmail.Visible = false;
        }

        #endregion

        #region Helpers

        protected string GetUserTypesNeeded()
        {
            if (CurrentUser.UserTypesNeeded == null)
                return string.Empty;

            string[] types = CurrentUser.UserTypesNeeded.Split(new[] { ',' });
            var sb = new StringBuilder("<ul>");
            foreach (string type in types)
            {
                switch ((UserTypes)Enum.Parse(typeof(UserTypes), type))
                {
                    case UserTypes.Businessman:
                        sb.Append("<li>Jag söker kompetenser och delägare till min verksamhet." + CurrentUser.DescBusinessman + "</li>");
                        break;

                    case UserTypes.Entrepreneur:
                        sb.Append("<li>Jag söker efter en person som kan starta upp och driva företag. " + CurrentUser.DescEntrepreneur + "</li>");
                        break;

                    case UserTypes.Innovator:
                        sb.Append("<li>Jag söker efter folk med idéer som de vill förverkliga. " + CurrentUser.DescInnovator + "</li>");
                        break;

                    case UserTypes.Investor:
                        sb.Append("<li>Jag söker efter spännande idéer och företag att investera i. " + CurrentUser.DescInvestor + "</li>");
                        break;

                    case UserTypes.Retiring:
                        sb.Append("<li>Jag söker efter personer som kan ta över mitt företag då jag går i pension snart. " + CurrentUser.DescRetiring + "</li>");
                        break;

                    case UserTypes.Financing:
                        sb.Append("<li>Jag söker efter personer med kunskap och kapital att investera i min idé eller företag. " + CurrentUser.DescFinancing + "</li>");
                        break;

                    default:
                        sb.Append("<li>Detta borde aldrig hända</li>");
                        break;
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        protected string GetInitializeScript()
        {
            if (Membership.GetUser() != null)
                return "InitializeMemberPage('" + UserIDOfUserBeingViewed + "', '" + Current.UserID + "')";
            else
                return string.Empty;
        }

        protected string GetHtmlForSniHeader()
        {
            string sniHeadID = CurrentUser.SniHeadID;
            if (sniHeadID != null)
            {
                var sniHead = SniHeadService.GetSniHead(sniHeadID);
                var usersInSegment = UserService.GetUsersBySni(sniHeadID);
             
                if (WebHelpers.IsLoggedIn())
                    usersInSegment = (from x in usersInSegment where x.UserId != Current.UserID select x);

                if (usersInSegment != null && usersInSegment.Any())
                {
                    var userIDs = usersInSegment.Select(u => u.UserId.ToString()).ToList();
                    int count = usersInSegment.Count();
                    int currIndex = userIDs.IndexOf(CurrentUser.UserId.ToString());
                    if (count - currIndex == 1) // if current is last
                        currIndex = -1;
                    return string.Format(SegmentHtml, sniHead.Title, sniHead.Title, sniHeadID.Trim(), count, userIDs[currIndex + 1]);
                }
            }
            return string.Empty;
        }

        protected string GetSendMailScript()
        {
            const string sendMailScript = "SendMail('{0}', '{1}', {2})";
            return string.Format(sendMailScript, Current.UserID, UserIDOfUserBeingViewed, "$('#txtMessage').val()");
        }

        protected string GetCurrentSniHead()
        {
            var sniHead = SniHeadService.GetSniHead(CurrentUser.SniHeadID);
            if (sniHead == null)
                return "";
            
            return sniHead.Title;
        }

        protected string GetCurrentUserUrl(bool withHttp)
        {
            if (string.IsNullOrEmpty(CurrentUser.Url))
                return ""; 
            
            if (CurrentUser.Url.StartsWith(Http))
            {
                if (withHttp)
                    return CurrentUser.Url;
                
                return CurrentUser.Url.Replace(Http, "");
            }
            if (withHttp)
                return Http + CurrentUser.Url;
            
            return CurrentUser.Url;
        }

        #endregion
    }
}