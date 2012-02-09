//<%@ WebHandler Language="C#" Class="AutoCompleteHandler" %>

using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Collections.Generic;
using Yoyyin.Domain;
using Yoyyin.Domain.SearchWords;

namespace Yoyyin.Web.Handlers
{
    [WebService(Namespace = "yoyyin.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProfileSearchAutoCompleteHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;

            var profileSearchWordsProvider = new ProfileSearchWordsProvider(new CachedItemProvider<IList<string>>());
            var organizer = new SearchWordsOrganizer(profileSearchWordsProvider);
            var searchWordsByRequest = FilterSearchWordsByRequest(context, organizer.GetAllSearchWords());

            var jsSerializer = new JavaScriptSerializer();
            if (searchWordsByRequest != null)
                context.Response.Write(jsSerializer.Serialize(searchWordsByRequest));
        }

        private static List<string> FilterSearchWordsByRequest(HttpContext context, IEnumerable<string> searchWords)
        {
            string input = context.Request.QueryString["term"];
            var searchWordsSeparated = new List<string>();
            foreach (string searchWord in searchWords)
            {
                foreach (string s in searchWord.Split(','))
                {
                    if (s.ToLower().StartsWith(input))
                        searchWordsSeparated.Add(s);
                }
            }
            return searchWordsSeparated;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}