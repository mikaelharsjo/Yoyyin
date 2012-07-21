using System.Collections.Generic;

namespace Yoyyin.Mvc.Models.BreadCrumb
{
    public class ListBreadCrumb : BreadCrumb
    {
        public ListBreadCrumb()
        {
            Items =
                new List<BreadCrumbItem>
                    {
                        new BreadCrumbItem {Text = "Hem", Url = "/Home"},
                        new BreadCrumbItem {Text = "Aff�rsid�er"},
                        new BreadCrumbItem {Text = "Alla", IsLast = true}
                    };
        }
    }
}