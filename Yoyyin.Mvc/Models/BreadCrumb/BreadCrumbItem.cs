namespace Yoyyin.Mvc.Models.BreadCrumb
{
    public class BreadCrumbItem 
    {
        public string Text { get; set; }
        public string Url { get; set; }
        
        public string  GetMarkup()
        {
            string template = Url == string.Empty
                                  ? "<li>{1}<span class='divider'>/</span></li>"
                                  : "<li><a href='{0}'>{1}</a> <span class='divider'>/</span></li>";
            return string.Format(template, Url, Text);
        }
    }
}