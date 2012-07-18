using System.Security.Principal;

namespace Yoyyin.Mvc.Models.UserRoles
{
    public interface IAuthorizer
    {
        IPrincipal AuthorizePrincipal(IPrincipal principal);
    }
}