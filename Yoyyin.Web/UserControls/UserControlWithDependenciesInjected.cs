using System.Web;
using System.Web.UI;
using Autofac;
using Autofac.Integration.Web;

namespace Yoyyin.Web.UserControls
{
    public class UserControlWithDependenciesInjected : UserControl
    {
        public UserControlWithDependenciesInjected()
        {
            // autofac doesn´t support usercontrols automagically
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            cp.RequestLifetime.InjectProperties(this);
        }
    }
}