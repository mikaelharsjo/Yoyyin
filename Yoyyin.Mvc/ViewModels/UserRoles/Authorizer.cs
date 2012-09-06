using System.Linq;
using System.Security.Principal;

namespace Yoyyin.Mvc.Models.UserRoles
{
    public class Authorizer : IAuthorizer
    {
        private static readonly IPrincipal DefaultPrincipal = new GenericPrincipal(new GenericIdentity(""),
                                                                                   new string[0]);

        public Authorizer(IUserRoles userRoles)
        {
            UserRoles = userRoles;
        }

        public IUserRoles UserRoles { get; private set; }

        #region IAuthorizer Members

        public IPrincipal AuthorizePrincipal(IPrincipal principal)
        {
            return (
                       from p in new[] {principal}
                       let identity = p.Identity
                       where identity != null
                       where identity.IsAuthenticated
                       select new GenericPrincipal(identity, UserRoles.GetUserRoles(identity.Name)))
                       .FirstOrDefault() ?? DefaultPrincipal;
        }

        #endregion
    }
}