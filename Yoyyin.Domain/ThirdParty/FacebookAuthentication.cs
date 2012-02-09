using System;
using System.Net;
using System.Collections.Specialized;
using System.Web;
using System.IO;

namespace Yoyyin.Domain.ThirdParty
{
    public class FacebookAuthentication
    {
        public enum Method { Get, Post };
        public const string Authorize = "https://graph.facebook.com/oauth/authorize";
        public const string AccessToken = "https://graph.facebook.com/oauth/access_token";
        public const string CallbackUrl = "http://yoyyin.com/Register.aspx";

        private string _consumerKey = "";
        private string _consumerSecret = "";
        private string _token = "";

        #region Properties

        public string ConsumerKey
        {
            get
            {
                if (_consumerKey.Length == 0)
                {
                    _consumerKey = "107424245989069"; //Your application ID
                }
                return _consumerKey;
            }
            set { _consumerKey = value; }
        }

        public string ConsumerSecret
        {
            get
            {
                if (_consumerSecret.Length == 0)
                {
                    _consumerSecret = "85fc54f9d972981bbe5ebde54056f0c9"; //Your application secret
                }
                return _consumerSecret;
            }
            set { _consumerSecret = value; }
        }

        public string Token { get { return _token; } set { _token = value; } }

        #endregion

        /// <summary>
        /// Get the link to Facebook's authorization page for this application.
        /// </summary>
        /// <returns>The url with a valid request token, or a null string.</returns>
        public string AuthorizationLinkGet()
        {
            string s = string.Format("{0}?client_id={1}&redirect_uri={2}", Authorize, this.ConsumerKey, CallbackUrl);
            s += "&scope=email,user_about_me,user_website";

            return s;
        }

        /// <summary>
        /// Exchange the Facebook "code" for an access token.
        /// </summary>
        /// <param name="authToken">The oauth_token or "code" is supplied by Facebook's authorization page following the callback.</param>
        public void AccessTokenGet(string authToken)
        {
            Token = authToken;
            string accessTokenUrl = string.Format("{0}?client_id={1}&redirect_uri={2}&client_secret={3}&code={4}",
            AccessToken, this.ConsumerKey, CallbackUrl, this.ConsumerSecret, authToken);

            string response = WebRequest(Method.Get, accessTokenUrl, String.Empty);

            if (response.Length > 0)
            {
                //Store the returned access_token
                NameValueCollection qs = HttpUtility.ParseQueryString(response);

                if (qs["access_token"] != null)
                {
                    this.Token = qs["access_token"];
                }
            }
        }

        /// <summary>
        /// Web Request Wrapper
        /// </summary>
        /// <param name="method">Http Method</param>
        /// <param name="url">Full url to the web resource</param>
        /// <param name="postData">Data to post in querystring format</param>
        /// <returns>The web server response.</returns>
        public string WebRequest(Method method, string url, string postData)
        {

            HttpWebRequest webRequest = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = method.ToString();
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.UserAgent = "[You user agent]";
                webRequest.Timeout = 20000;

                if (method == Method.Post)
                {
                    webRequest.ContentType = "application/x-www-form-urlencoded";

                    //POST the data.
                    var requestWriter = new StreamWriter(webRequest.GetRequestStream());

                    try
                    {
                        requestWriter.Write(postData);
                    }

                    finally
                    {
                        requestWriter.Close();
                    }
                }

                responseData = WebResponseGet(webRequest);
            }
            return responseData;
        }

        /// <summary>
        /// Process the web response.
        /// </summary>
        /// <param name="webRequest">The request object.</param>
        /// <returns>The response data.</returns>
        public string WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                if (webRequest != null) responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                if (responseReader != null) responseData = responseReader.ReadToEnd();
            }
            finally
            {
                if (webRequest != null)
                {
                    var responseStream = webRequest.GetResponse().GetResponseStream();
                    if (responseStream != null)
                        responseStream.Close();
                }
                if (responseReader != null) responseReader.Close();
            }

            return responseData;
        }
    }
}