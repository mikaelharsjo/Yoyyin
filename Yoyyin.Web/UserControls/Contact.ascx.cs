using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Autofac;
using Autofac.Integration.Web;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;

namespace Yoyyin.Web.UserControls
{
    public class UserControlWithDependenciesInjected : UserControl
    {
        public UserControlWithDependenciesInjected()
        {
            // autofac doesn´t support masterpages automagically
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            cp.RequestLifetime.InjectProperties(this);
        }
    }

    public partial class Contact : UserControlWithDependenciesInjected
    {
        const string UserIDMicke = "fc24985e-fe13-45e3-b9a9-a86347762379";
        const string UserIDAnders = "62bb6821-dc9a-4375-ae4b-a09cc255d08f";
        const string UserIDPeter = "db29e60a-2648-4f4f-a8d8-dfb3d7dba544";

        public IUserService UserService { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var yoyyinOwners = new List<IUser>();
            var guidMicke = new Guid(UserIDMicke);
            var guidAnders = new Guid(UserIDAnders);
            var guidPeter = new Guid(UserIDPeter);

            yoyyinOwners.Add(UserService.GetUser(guidAnders));
            yoyyinOwners.Add(UserService.GetUser(guidPeter));
            yoyyinOwners.Add(UserService.GetUser(guidMicke));

            lstMembers.DataSource = yoyyinOwners;
            lstMembers.DataBind();
        }
    }
}