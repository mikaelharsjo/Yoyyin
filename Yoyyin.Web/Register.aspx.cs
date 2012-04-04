using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using Yoyyin.Data;
using Yoyyin.Data.UnitOfWork;
using Yoyyin.Domain;
using Yoyyin.Domain.Extensions;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.ThirdParty;
using Yoyyin.Domain.Users;
using Yoyyin.Web.Helpers;
using UserTypes = Yoyyin.Domain.Enumerations.UserTypes;

namespace Yoyyin.Web
{
    [ScriptService]
    public partial class Register : Page
    {
        private Dictionary<WizStep, string> _stepTipHtml;
        private IUser _user;
        public IUserRepository UserRepository { get; set; }
        public IUserService UserService { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public string FbID { get; set; }
        public string FbEmail { get; set; }
        public string FbLocationName { get; set; }
        public string FbWebSite { get; set; }
        public string FbName { get; set; }

        public string FbCity
        {
            get
            {
                if (FbLocationName == null)
                    return string.Empty;
                string[] location = FbLocationName.Split(',');
                if (location.Length > 0)
                    return location[0];

                return string.Empty;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _stepTipHtml = new Dictionary<WizStep, string>
                               {
                                   {
                                       WizStep.Start,
                                       "<div class='marginBottom'>Välj ett lösenord med minst sex tecken.</div><div class='marginBottom'><img src='Styles/Images/lightbulb.png' class='marginRight' />Har du redan ett facebook-konto kan du spara tid genom att hämta uppgifter därifrån.</div>"
                                       },
                                   {
                                       WizStep.PersonalInfo,
                                       "<div class='marginBottom'><img src='Styles/Images/lightbulb.png' alt='Tips' class='marginRight' />Du måste fylla i ett namn men vill du vara lite privat så kan du hitta på ett användarnamn istället.</div><div class='marginBottom'><img src='Styles/Images/lightbulb.png' alt='Tips' class='marginRight' />Fält markerade med <img src='Styles/Images/magnifier.png' alt='Sökbart' /> efter blir sökbara.</div><div class='marginBottom'><img src='Styles/Images/lightbulb.png' alt='Tips' class='marginRight' />Om du fyller i adress korrekt så visas din profil på kartan vid sökning, det räcker att ange stad för grov placering.</div><div class='marginBottom'>Det kan vara din hemadress eller en adress som är knuten till din affärsidé.</div>"
                                       },
                                   {
                                       WizStep.Role,
                                       "<div class='marginBottom'>Välj den roll som du tycker passar bäst in på dig.</div>Den används för att matcha ihop dig med rätt affärspartner."
                                       },
                                   {
                                       WizStep.RoleNeeded,
                                       "<div class='marginBottom'>Välj dom alternativ som passar.</div>Dom används för att matcha ihop dig med rätt affärspartner."
                                       },
                                   {
                                       WizStep.Searchwords,
                                       "<div class='marginBottom'><strong>Taggar/kompetenser</strong> används för att matcha ihop dig med andra affärspartners. Skriv generellt dvs 'restaurang' och inte 'kinarestaurangerfarenhet' för att få flera matchningar.</div>"
                                       },
                                   {
                                       WizStep.Files,
                                       "<div class='marginBottom'><img src='Styles/Images/lightbulb.png' alt='Tips' class='marginRight' />Har du hämtat uppgifter från Facebook kommer din profilbild att visas här på Yoyyin också.</div><div class='marginTop'>Vill du ha en annan bild här på Yoyyin så ladda upp den nu.</div>"
                                       },
                                   {
                                       WizStep.Idea,
                                       "<div class='marginBottom'><img src='Styles/Images/lightbulb.png' alt='Tips' class='marginRight' />Beskriv din affärsidé kortfattat men utan att avslöja affärshemligheter, den blir sökbar av andra besökare.</div><div class='marginBottom'><img src='Styles/Images/lightbulb.png' alt='Tips' class='marginRight' />Du kan alltid färdigställa eller ändra i din profil på 'Min profil' under 'Redigera profil'.</div>"
                                       }
                               };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebHelpers.IsLoggedIn())
            {
                var btnFacebook = (ImageButton) GetControlFromWizardStep(WizStep.Start, "btnFacebook");
                if (btnFacebook != null)
                    btnFacebook.Visible = false;
            }
            Form.Attributes.Add("novalidate", "novalidate");
            MetaDescription = "Bli medlem och sökbar för andra affärsparners, företagare och entreprenörer";
            
            if (Request["code"] != null)
                GetInfoFromFacebook();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            SetTipHtml();
            DataBindUserTypes();
        }

        private Control GetControlFromWizardStep(WizStep stepIndex, string controlID)
        {
            Control stepContent =
                ((TemplatedWizardStep) wizard.WizardSteps[(int) stepIndex]).ContentTemplateContainer;
            return stepContent.FindControl(controlID);
        }

        private string GetTextBoxTextFromWizardStep(WizStep stepIndex, string controlID)
        {
            Control control = GetControlFromWizardStep(stepIndex, controlID);
            if (control != null)
            {
                var textBox = (TextBox) control;
                return textBox.Text;
            }
            
            return string.Empty;
        }

        private void DataBindUserTypes()
        {
            var repUserTypes = (Repeater) GetControlFromWizardStep(WizStep.RoleNeeded, "repUserTypes");
            if (repUserTypes != null)
            {
                repUserTypes.DataSource = EnumHelper.GetAll<UserTypes>();
                repUserTypes.DataBind();
            }
        }


        private void GetInfoFromFacebook()
        {
            try
            {
                string url = "";
                var oAuth = new FacebookAuthentication();
                //Get the access token and secret.
                oAuth.AccessTokenGet(Request["code"]);

                if (oAuth.Token.Length > 0)
                {
                    //We now have the credentials, so we can start making API calls
                    url = "https://graph.facebook.com/me?access_token=" + oAuth.Token;
                    string jsonText = oAuth.WebRequest(FacebookAuthentication.Method.Get, url, String.Empty);

                    JObject json = JObject.Parse(jsonText);
                    FbID = json["id"].ToString().Replace("\"", "");
                    FbEmail = json["email"].ToString().Replace("\"", "");
                    FbLocationName = json["location"]["name"].ToString().Replace("\"", "");
                    FbWebSite = json["website"].ToString().Replace("\"", "");
                    FbName = json["name"].ToString().Replace("\"", "");

                    if (FbID != null)
                        imgYoyyin.ImageUrl = string.Format(WebHelpers.FacebookImageurlLarge, FbID);

                    if (!IsPostBack)
                    {
                        var txtUserName =
                            (TextBox) createUserWizardStep.ContentTemplateContainer.FindControl("UserName");
                        txtUserName.Text = FbEmail;
                    }
                }
            }
            catch (Exception ex)
            {
                var mailHelper = new MailHelper();
                mailHelper.SendErrorMail("Register.aspx: GetInfoFromFacebook" + ex.Message);
            }
        }

        private void SetTipHtml()
        {
            var currentTip = _stepTipHtml[(WizStep) wizard.ActiveStepIndex];
            divTips.InnerHtml = currentTip;
        }

        protected void BtnFacebook_Click(object sender, EventArgs e)
        {
            var fb = new FacebookAuthentication();
            Response.Redirect(fb.AuthorizationLinkGet());
        }

        protected void OnCreatedUser(object sender, EventArgs e)
        {
            var txtUserName = (TextBox) createUserWizardStep.ContentTemplateContainer.FindControl("UserName");
            var txtPassword = (TextBox) createUserWizardStep.ContentTemplateContainer.FindControl("Password");

            Current.UserName = txtUserName.Text;
            MembershipUser mu = Membership.GetUser(Current.UserName);

            if (mu != null)
            {
                mu.Email = Current.UserName;
                Membership.UpdateUser(mu);
            }

            Session.Add("currentPassword", txtPassword.Text);
        }

        protected void nextButtonClick(object sender, EventArgs e)
        {
            litJS.Text = "";

            switch ((WizStep) wizard.ActiveStepIndex)
            {
                case WizStep.Start:
                    SaveStartStep();

                    break;

                case WizStep.PersonalInfo:
                    SavePersonalInfoStep();

                    break;

                case WizStep.Role:
                    SaveRoleStep();

                    break;

                case WizStep.RoleNeeded:
                    SaveRoleNeededStep();

                    break;

                case WizStep.Searchwords:
                    SaveStepSearchWords();

                    break;
                case WizStep.Files:
                    SaveStepFiles();

                    break;
            }
        }

        private void SaveStartStep()
        {
            // not logged in yet so get user via username
            MembershipUser mu = Membership.GetUser(Current.UserName);
            litEmail.Text = mu.Email;
            const string script =
                "$(document).ready(function () { $('#divWelcome').show(); $('#divWelcome').center(); $('#popBg').show(); $('#popBg').click(function () { $('#divWelcome').hide(); $('#popBg').hide(); });}); document.forms[0].action = 'Register.aspx';";
            litJS.Text = script;
            Master.LoginStatus.Visible = true;
            Master.LitLoggedInInfo.Text = string.Format(SiteMaster.LoggedInInfo, mu.UserName, "");
            Master.ShowToolbar();

            _user = (IUser)new User
                        {
                            UserId = new Guid(mu.ProviderUserKey.ToString()),
                            CompanyName = "",
                            FacebookID = FbID,
                            Active = true,
                            ShowAddress = true,
                            ShowOnMap = true,
                            ShowEmail = false,
                            UserType = (int) UserTypes.Entrepreneur,
                            Street = "",
                            ZipCode = "",
                            Phone = string.Empty,
                            Url = ""
                        };

            /* default settings */

            GetPropertiesFromFacebookIfAny();

            _user.BusinessTitle = string.Empty;
            _user.BusinessDescription = string.Empty;

            //UserService.CreateUserInDb(_user);
        }

        private void SaveStepFiles()
        {
            _user = UserRepository.GetUser(Current.UserID);

            var fileImage = (FileUpload) GetControlFromWizardStep(WizStep.Files, "fileImage");

            if (fileImage.FileBytes.Length > 0)
            {
                _user.Image = fileImage.FileBytes;
                imgYoyyin.Visible = false;
                userImage.Visible = true;
                userImage.UserID = Current.UserID;
            }

            var fileCV = (FileUpload) GetControlFromWizardStep(WizStep.Files, "fileCV");

            if (fileCV.HasFile)
            {
                fileCV.SaveAs(Server.MapPath("~/Upload") + "\\" + fileCV.FileName);
                _user.CVFileName = fileCV.FileName;
            }

            //UserService.Save(_user);
            UnitOfWork.Commit();
        }

        private void SaveStepSearchWords()
        {
            _user = UserRepository.GetUser(Current.UserID);

            _user.SearchWords = GetTextBoxTextFromWizardStep(WizStep.Searchwords, "txtSearchWords");
            _user.SearchWordsCompetence = GetTextBoxTextFromWizardStep(WizStep.Searchwords, "txtSearchWordsCompetence");
            _user.SearchWordsCompetenceNeeded = GetTextBoxTextFromWizardStep(WizStep.Searchwords,
                                                                             "txtSearchWordsCompetenceNeeded");
            //UserService.Save(_user);
        }

        private void SaveRoleNeededStep()
        {
            _user = UserRepository.GetUser(Current.UserID);

            _user.UserTypesNeeded = WebHelpers.GetUserTypesNeededAsCsvAndSetDescriptionsFromRepeater(_user,
                                                                                                     (Repeater)
                                                                                                     GetControlFromWizardStep
                                                                                                         (WizStep.
                                                                                                              RoleNeeded,
                                                                                                          "repUserTypes"));
        }

        private void SaveRoleStep()
        {
            _user = UserRepository.GetUser(Current.UserID);

            _user.UserType = int.Parse(Request["radioRole"]);
            _user.UserTypeDescription = GetTextBoxTextFromWizardStep(WizStep.Role, "txtUserTypeDescription");

            //UserService.Save(_user);
            UnitOfWork.Commit();
        }

        private void SavePersonalInfoStep()
        {
            _user = UserRepository.GetUser(Current.UserID);

            _user.CompanyName = GetTextBoxTextFromWizardStep(WizStep.PersonalInfo, "companyName");
            _user.Name = GetTextBoxTextFromWizardStep(WizStep.PersonalInfo, "name");
            _user.Alias = GetTextBoxTextFromWizardStep(WizStep.PersonalInfo, "alias");
            litName.Text = _user.GetDisplayName();
            _user.Street = GetTextBoxTextFromWizardStep(WizStep.PersonalInfo, "street");
            _user.ZipCode = GetTextBoxTextFromWizardStep(WizStep.PersonalInfo, "zipCode");
            _user.City = GetTextBoxTextFromWizardStep(WizStep.PersonalInfo, "city");
            _user.Phone = GetTextBoxTextFromWizardStep(WizStep.PersonalInfo, "phone");
            _user.Url = GetTextBoxTextFromWizardStep(WizStep.PersonalInfo, "url");

            var gh = new GoogleHelper();
            gh.UpdateUserCoordsFromGeocodingService(_user);
            
            //UserService.Save(_user);
            UnitOfWork.Commit();
        }

        protected void wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            SaveStepIdea();

            Session["currentUserID"] = null;

            MembershipUser membershipUser = Membership.GetUser();

            if (membershipUser == null)
                membershipUser = Membership.GetUser(Current.UserID, true);

            if (membershipUser == null)
                LoginUser(membershipUser.UserName, Session["currentPassword"].ToString());
            else
                Response.Redirect("~/Member.aspx?FirstTime=1");
        }

        private void SaveStepIdea()
        {
            _user = UserService.GetCurrentUser();

            Control step6Content =
                ((TemplatedWizardStep) wizard.WizardSteps[(int) WizStep.Idea]).ContentTemplateContainer;
            if (step6Content != null)
            {
                _user.BusinessTitle = GetTextBoxTextFromWizardStep(WizStep.Idea, "businessTitle");

                string desc = GetTextBoxTextFromWizardStep(WizStep.Idea, "businessDesc");
                desc = desc
                        .Replace("\n", "<br />")
                        .Replace("\r", "")
                        .Replace("\t", "");

                _user.BusinessDescription = desc;

                _user.SniHeadID = ((DropDownList) step6Content.FindControl("ddlSniHead")).SelectedValue;
                _user.SniNo = ((DropDownList) step6Content.FindControl("ddlSniItem")).SelectedValue;

                //UserService.Save(_user);
                UnitOfWork.Commit();
            }
        }

        private void GetPropertiesFromFacebookIfAny()
        {
            if (FbName != null)
            {
                _user.Name = FbName;
                var name = (TextBox) GetControlFromWizardStep(WizStep.PersonalInfo, "name");
                if (name != null)
                    name.Text = FbName;
                litName.Text = FbName;
            }
            else
                _user.Name = string.Empty;

            if (FbCity != string.Empty)
            {
                _user.City = FbCity;
                var city = (TextBox) GetControlFromWizardStep(WizStep.PersonalInfo, "city");
                city.Text = FbCity;
            }
            else
                _user.City = string.Empty;

            if (FbWebSite != null)
            {
                _user.Url = FbWebSite;
                var url = (TextBox) GetControlFromWizardStep(WizStep.PersonalInfo, "url");
                if (url != null)
                    url.Text = FbWebSite;
            }
            else
                _user.Url = string.Empty;
        }

        private void LoginUser(string userName, string password)
        {
            if (!Membership.ValidateUser(userName, password)) return;

            FormsAuthentication.SetAuthCookie(userName, true);
            FormsAuthentication.RedirectFromLoginPage(userName, true);
        }

        #region Nested type: WizStep

        private enum WizStep
        {
            Start,
            PersonalInfo,
            Role,
            RoleNeeded,
            Searchwords,
            Files,
            Idea
        }

        #endregion
    }
}