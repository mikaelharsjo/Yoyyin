using System;
using Yoyyin.Data;
using Yoyyin.Domain.Services;
using UserTypes = Yoyyin.Domain.Enumerations.UserTypes;

namespace Yoyyin.Web.UserControls
{
    public partial class AdvancedSearch : System.Web.UI.UserControl
    {
        public IUserRepository UserRepository { get; set; }
        public IUserService UserService { get; set; }
        public ISniHeadService SniHeadService { get; set; }
        public IRepository<SniHead> SniHeadRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserRepository.GetUser(Current.UserID);

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

            ddlSniHead.DataSource = SniHeadRepository.FindAll();
            ddlSniHead.DataBind();
        }
    }
}