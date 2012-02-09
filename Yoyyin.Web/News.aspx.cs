using System;
using System.Web.Security;
using Yoyyin.Domain;

namespace Yoyyin.Web
{
    public partial class News : System.Web.UI.Page
    {
        public User CurrentUser { get; set; }
        public Guid CurrentUserId = Guid.Empty;
        public MembershipUser Mu { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Mu = Membership.GetUser();
            if (Mu != null)
                CurrentUserId = new Guid(Mu.ProviderUserKey.ToString());
            else
                Server.Transfer("~/Default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}