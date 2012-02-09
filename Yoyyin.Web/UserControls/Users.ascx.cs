using System;
using System.Collections.Generic;
using Yoyyin.Domain;
using Yoyyin.PresentationModel;

namespace Yoyyin.Web.UserControls
{
    public partial class Users : System.Web.UI.UserControl
    {
        public IEnumerable<IUser> SrcUsers { get; set; }
        public UserPresenter UserPresenter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lstMembers.DataSource = UserPresenter.Presentate(SrcUsers);
            lstMembers.DataBind();
        }
    }
}