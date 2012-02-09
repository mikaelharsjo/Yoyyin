using System;
using Yoyyin.Domain.Enumerations;
using Yoyyin.Domain.Services;

namespace Yoyyin.Web.UserControls
{
    public partial class AdvancedSearch : System.Web.UI.UserControl
    {
        public IUserService UserService { get; set; }
        public ISniHeadService SniHeadService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserService.GetUser(Current.UserID);

            if (user.UserTypesNeeded != null)
            {
                const int innovator = (int) UserTypes.Innovator;
                const int entrepreneur = (int) UserTypes.Entrepreneur;
                const int investor = (int) UserTypes.Investor;

                if (user.UserTypesNeeded.Contains(entrepreneur.ToString()))
                    chkentrepreneur.Checked = true;
                if (user.UserTypesNeeded.Contains(innovator.ToString()))
                    chkinnovator.Checked = true;
                if (user.UserTypesNeeded.Contains(investor.ToString()))
                    chkinvestor.Checked = true;
            }

            ddlSniHead.DataSource = SniHeadService.GetAllSniHeadItems();
            ddlSniHead.DataBind();
        }
    }
}