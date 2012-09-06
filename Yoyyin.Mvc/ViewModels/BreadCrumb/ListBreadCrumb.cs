using System.Collections.Generic;

namespace Yoyyin.Mvc.ViewModels.BreadCrumb
{
    public class ListBreadCrumb : BreadCrumb
    {
        public ListBreadCrumb()
        {
            Items =
                new List<BreadCrumbItem>
                    {
                        new BreadCrumbItem {Text = "Hem", Url = "/Home"},
                        new BreadCrumbItem {Text = "Affärsidéer"},
                        new BreadCrumbItem {Text = "Alla", IsLast = true}
                    };
        }
    }
}