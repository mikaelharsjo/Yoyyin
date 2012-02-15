using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;

namespace Yoyyin.Web.Helpers
{
    public class NewestMembersHelper
    {
        public IEnumerable<MembershipUser> GetNewestMembersFromCacheOrDb()
        {
            IEnumerable<MembershipUser> newMembers;
            if (HttpContext.Current.Cache["NewestMembers"] != null)
                newMembers = HttpContext.Current.Cache["NewestMembers"] as IEnumerable<MembershipUser>;
            else
            {
                var memUsers = from MembershipUser user in Membership.GetAllUsers() select user;
                newMembers = memUsers.OrderByDescending(x => x.CreationDate).Take(5);
                HttpContext.Current.Cache.Insert("NewestMembers", newMembers, null, DateTime.Now.AddHours(24), Cache.NoSlidingExpiration);
            }
            return newMembers;
        }
    }
}