using System.Collections.Generic;
using System.Linq;

namespace Yoyyin.Mvc.ViewModels.BreadCrumb
{
    public class BreadCrumb : IBreadCrumb
    {
        public IEnumerable<BreadCrumbItem> Items { get; set; }

        // TODO: refactor with Razor foreach + partial
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