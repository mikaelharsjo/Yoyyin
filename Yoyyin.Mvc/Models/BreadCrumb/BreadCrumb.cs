using System.Collections.Generic;
using System.Linq;

namespace Yoyyin.Mvc.Models.BreadCrumb
{
    public class BreadCrumb : IBreadCrumb
    {
        public IEnumerable<BreadCrumbItem> Items { get; set; }
        public string GetMarkup()
        {
            if (Items.Any())
            {
                string template = "<ul class='breadcrumb'>{0}</ul>";

                string itemsMarkup = string.Join("", Items.Select(item => item.GetMarkup()).ToArray());

                return string.Format(template, itemsMarkup);
            }

            return string.Empty;
        }
    }
}