using System.Collections.Generic;

namespace Yoyyin.Mvc.Models.UserRoles
{
    public class UserRoles : Dictionary<string,string[]>, IUserRoles
    {
        public string[] GetUserRoles(string userName)
        {
            string[] roles;
            return TryGetValue(userName, out roles) ? roles : new string[0];
        }
    }
}