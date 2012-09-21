using System.Web;

namespace Yoyyin.Mvc.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString PageHeader(this System.Web.Mvc.HtmlHelper html, object title, object byLine)
        {
            title = title ?? string.Empty;
            byLine = byLine ?? string.Empty;

            const string template = @"<div class='page-header'>
                                        <h1>{0}. <small>{1}</small></h1>            
                                    </div>";

            return html.Raw(string.Format(template, title.ToString(), byLine.ToString()));
        }
    }
}
