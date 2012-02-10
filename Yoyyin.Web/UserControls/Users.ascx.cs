using System;
using System.Collections.Generic;
using System.Web;
using Autofac;
using Autofac.Integration.Web;
using Yoyyin.Domain;
using Yoyyin.PresentationModel;

namespace Yoyyin.Web.UserControls
{
    public partial class Users : UserControlWithDependenciesInjected
    {
        public IEnumerable<IUser> SrcUsers { get; set; }
        public IUserPresenter UserPresenter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lstMembers.DataSource = UserPresenter.Presentate(SrcUsers);
            lstMembers.DataBind();
        }
    }
}