using System;
using System.Linq;
using Yoyyin.Data.Core.Repositories;
using Yoyyin.Domain.Services;
using Yoyyin.Web.Helpers;

namespace Yoyyin.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        const int FacePileCount = 8;
        public IUserRepository UserRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {   
            if (WebHelpers.IsLoggedIn())
            {
                loginStart.Visible = false;
                lnkRegister.Visible = false;
                hiddenLoggedIn.Value = "true";
                
                lstNewest.DataSource = UserRepository
                                        .GetLastActiveUsersWithImage()
                                        .Take(FacePileCount);
                lstNewest.DataBind();
            }
            else
                hiddenLoggedIn.Value = "false";

            Page.MetaDescription = "Yoyyin är en gratis mötesplats och matchningstjänst för dig som är (eller vill bli) företagare och entreprenör. Här kan du hitta andra att starta eller utveckla ditt företag tillsammans med";
            Page.MetaKeywords = "affärspartner,affärskollega,entreprenör,företagare,affärsidé,partner,hitta,söker,sökes,matchning";                     
        }

        public void LoggedIn(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}
