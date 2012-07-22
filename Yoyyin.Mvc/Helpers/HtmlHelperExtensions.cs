using System.Web;

namespace Yoyyin.Mvc.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString PageHeader(this System.Web.Mvc.HtmlHelper html, string title, string byLine)
        {
            if (title == null && byLine == null) return html.Raw("");

            const string template = @"<div class='page-header'>
                                        <h1>{0}. <small>{1}</small></h1>            
                                    </div>";

            return html.Raw(string.Format(template, title, byLine));
        }
    }
}
