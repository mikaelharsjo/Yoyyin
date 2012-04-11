using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;
using Yoyyin.Domain.ThirdParty;
using Yoyyin.Domain.Users;
using Yoyyin.Web.Helpers;
using UserTypes = Yoyyin.Domain.Enumerations.UserTypes;

namespace Yoyyin.Web
{
    public partial class EditUser : Page
    {
        private MembershipUser _mu;
        public Guid UserID;
        public IUserService UserService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            UserID = Current.UserID;
            _mu = Membership.GetUser();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.Attributes.Add("novalidate", "novalidate");

            if (!WebHelpers.IsLoggedIn()) return;

            var user = UserService.GetCurrentUser();

            if (!IsPostBack)
            {
                DataBindTextBoxes(user);

                DataBindUserTypes(user);

                ddlSniHeadID.SelectedValue = user.SniHeadID;

                chkShowAddress.Checked = user.ShowAddress;
                chkShowEmail.Checked = user.ShowEmail;
                chkShowOnMap.Checked = user.ShowOnMap;

                txtEmail.Text = _mu.Email;

                if (user.UserType == (int) UserTypes.Entrepreneur)
                    radioentrepreneurbusinessman.Checked = true;
                if (user.UserType == (int) UserTypes.Innovator)
                    radioinnovator.Checked = true;
                if (user.UserType == (int) UserTypes.Investor)
                    radioinvestor.Checked = true;
            }

            if (!string.IsNullOrEmpty(user.CVFileName))
            {
                lnkCV.NavigateUrl = "~/Upload/" + user.CVFileName;
                lnkCV.Text = user.CVFileName;
            }
            else
            {
                lnkCV.Visible = false;
                lnkRemoveCV.Visible = false;
            }
        }

        private void DataBindUserTypes(IUser user)
        {
            repUserTypes.DataSource = EnumHelper.GetAll<UserTypes>();
            repUserTypes.DataBind();

            foreach (RepeaterItem item in repUserTypes.Items)
            {
                var txtUserTypeDescription = (TextBox)item.FindControl("txtUserTypeDescription");
                var chkUserType = (CheckBox)item.FindControl("chkUserType");
                var hiddenUserType = (HiddenField)item.FindControl("hiddenUserType");
                var userType = (UserTypes)Enum.Parse(typeof (UserTypes), hiddenUserType.Value);
                switch (userType)
                {
                    case UserTypes.Businessman:
                        txtUserTypeDescription.Text = user.DescBusinessman;
                        break;
                    case UserTypes.Entrepreneur:
                        txtUserTypeDescription.Text = user.DescEntrepreneur;
                        break;
                    case UserTypes.Financing:
                        txtUserTypeDescription.Text = user.DescFinancing;
                        break;
                    case UserTypes.Innovator:
                        txtUserTypeDescription.Text = user.DescInnovator;
                        break;
                    case UserTypes.Investor:
                        txtUserTypeDescription.Text = user.DescInvestor;
                        break;
                    case UserTypes.Retiring:
                        txtUserTypeDescription.Text = user.DescRetiring;
                        break;
                    default:
                        throw new Exception("Invalid user type!");
                }

                if (user.UserTypesNeeded != null && user.UserTypesNeeded.Contains(hiddenUserType.Value))
                    chkUserType.Checked = true;
            }
        }

        private void DataBindTextBoxes(IUser user)
        {
            txtCompanyName.Text = user.CompanyName;
            txtName.Text = user.Name;
            txtStreet.Text = user.Street;
            txtZipCode.Text = user.ZipCode;
            txtCity.Text = user.City;
            txtPhone.Text = user.Phone;
            txtUrl.Text = user.Url;
            txtBusinessTitle.Text = user.BusinessTitle;
            txtBusinessDescription.Text = user.BusinessDescription;
            txtSearchWords.Text = user.SearchWords;
            txtSearchWordsCompetence.Text = user.SearchWordsCompetence;
            
            txtSearchWordsCompetenceNeeded.Text = user.SearchWordsCompetenceNeeded;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = UserService.GetCurrentUser();
            if (txtEmail.Text != _mu.Email)
            {
                _mu.Email = txtEmail.Text;
                divInfo.Visible = true;
                litInfo.Text =
                    "Din e-postadress är nu ändrad. Tänk på att du fortfarande loggar in med den e-postadress du först registrerade dig med. Den nya adressen används dock till alla meddelanden och funktioner på webbplatsen.";
            }

            Membership.UpdateUser(_mu);

            SetUserProperitesFromTextBoxes(user);

            user.ShowAddress = chkShowAddress.Checked;
            user.ShowEmail = chkShowEmail.Checked;
            user.ShowOnMap = chkShowOnMap.Checked;

            user.UserTypesNeeded = WebHelpers.GetUserTypesNeededAsCsvAndSetDescriptionsFromRepeater(user, repUserTypes);

            if (radioentrepreneurbusinessman.Checked)
                user.UserType = (int) UserTypes.Entrepreneur;
            if (radioinnovator.Checked)
                user.UserType = (int) UserTypes.Innovator;
            if (radioinvestor.Checked)
                user.UserType = (int) UserTypes.Investor;

            if (fileCV.HasFile)
            {
                fileCV.SaveAs(Server.MapPath("~/Upload") + "\\" + fileCV.FileName);
                user.CVFileName = fileCV.FileName;
            }

            if (fileImage.FileBytes.Length > 0)
                user.Image = fileImage.FileBytes;

            user.SniHeadID = ddlSniHeadID.SelectedValue;
            if (user.SniHeadID == string.Empty)
                user.SniHeadID = null;

            user.SniNo = ddlSniNo.SelectedValue;
            if (user.SniNo == string.Empty)
                user.SniNo = null;

            var gh = new GoogleHelper();
            gh.UpdateUserCoordsFromGeocodingService(user);

            //UserService.Save(user);

            Server.Transfer("~/Member.aspx");
        }

        private void SetUserProperitesFromTextBoxes(IUser user)
        {
            user.CompanyName = txtCompanyName.Text;
            user.Name = txtName.Text;
            user.Street = txtStreet.Text;
            user.ZipCode = txtZipCode.Text;
            user.City = txtCity.Text;
            user.Phone = txtPhone.Text;
            user.Url = txtUrl.Text;
            user.BusinessTitle = txtBusinessTitle.Text;
            user.BusinessDescription = txtBusinessDescription.Text;
            user.SearchWords = txtSearchWords.Text.ToLower();
            user.SearchWordsCompetence = txtSearchWordsCompetence.Text.ToLower();
            user.SearchWordsCompetenceNeeded = txtSearchWordsCompetenceNeeded.Text.ToLower();
        }
    }
}