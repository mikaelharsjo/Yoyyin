using System.Collections.Generic;

namespace Yoyyin.Mvc.ViewModels.BreadCrumb
{
    public class NoBreadCrumb : IBreadCrumb
    {
        public NoBreadCrumb()
        {
            Items = new BreadCrumbItem[0];
        }

        public IEnumerable<BreadCrumbItem> Items { get; private set; }
        public string GetMarkup()
        {
            return string.Empty;
        }
    }
}