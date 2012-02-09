using System;

namespace Yoyyin.Web
{
    public partial class Tools : System.Web.UI.Page
    {
        private string _secretLinkCssClass = "secretLink";
        public string SecretLinkCssClass
        {
            get { return _secretLinkCssClass; }
            set { _secretLinkCssClass = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.Security.Membership.GetUser() != null)
                SecretLinkCssClass = "";
        }
    }
}