using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;

namespace Yoyyin.Web.UserControls
{
    public partial class SearchResult : System.Web.UI.UserControl
    {
        public string Text { get; set; }
        public bool IsEntrepreneur { get; set; }
        public bool IsInnovator { get; set; }
        public bool IsInvestor { get; set; }
        public string SniHead { get; set; }
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var foundUsers = UserService.SearchAdvanced(Text, IsEntrepreneur, IsInnovator, IsInvestor, SniHead);

            lstUsers.DataSource = foundUsers;
            lstUsers.DataBind();

            litCount.Text = string.Format("Sökningen gav {0} träffar", foundUsers.Count());
        }
    }
}