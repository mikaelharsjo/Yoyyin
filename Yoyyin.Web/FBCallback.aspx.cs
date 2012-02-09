using System;
using Yoyyin.Domain.ThirdParty;

namespace Yoyyin.Web
{
    public partial class FBCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "";
            FacebookAuthentication oAuth = new FacebookAuthentication();

            if (Request["code"] == null)
            {
                //Redirect the user back to Facebook for authorization.
                Response.Redirect(oAuth.AuthorizationLinkGet());
            }
            else
            {
                //Get the access token and secret.
                oAuth.AccessTokenGet(Request["code"]);

                if (oAuth.Token.Length > 0)
                {
                    //We now have the credentials, so we can start making API calls
                    url = "https://graph.facebook.com/me?access_token=" + oAuth.Token;
                    string json = oAuth.WebRequest(FacebookAuthentication.Method.Get, url, String.Empty);
                    Response.Write(json);
                }
            }
        }
    }
}