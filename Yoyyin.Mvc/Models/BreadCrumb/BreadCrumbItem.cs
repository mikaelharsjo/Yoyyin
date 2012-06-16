namespace Yoyyin.Mvc.Models.BreadCrumb
{
    public class BreadCrumbItem 
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool IsLast { get; set; }
        
        public string  GetMarkup()
        {
            string dividerMarkup = IsLast ? "" : "<span class='divider'>/</span>";

            string template = string.IsNullOrEmpty(Url)
                                  ? "<li>{1}{2}</li>"
                                  : "<li><a href='{0}'>{1}</a> {2}</li>";
            return string.Format(template, Url, Text, dividerMarkup);
        }
    }
}