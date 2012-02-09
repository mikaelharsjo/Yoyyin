using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Yoyyin.Web
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MetaDescription = "Med Yoyyin kan du som är entreprenör, innovatör eller företagare hitta en affärspartner att starta eller utveckla företag tillsammans.";
            Page.Title = "Hitta en affärspartner med Yoyyin";
            lnkRegister.Visible = Membership.GetUser() == null;
        }

        protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            //e.CommandSource;
        }
    }
}