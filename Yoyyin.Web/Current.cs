using System;
using System.Web;
using System.Web.Security;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;

namespace Yoyyin.Web
{
    public class Current
    {
        public IUserService UserService { get; set; }
        
        public static Guid UserID
        {
            get 
            {
                var mu = Membership.GetUser();
                if (mu == null)
                    return Guid.Empty;

                var userID = new Guid(mu.ProviderUserKey.ToString());
                return userID;
            }
        }
        
        public static string UserName
        {
            get { return HttpContext.Current.Session["CurrentUserName"].ToString(); }
            set { HttpContext.Current.Session["CurrentUserName"] = value; }
        }
    }
}