using System.Collections.Generic;

namespace Yoyyin.Mvc.ViewModels.BreadCrumb
{
    public class ListBySniHeadBreadCrumb : BreadCrumb
    {
        public ListBySniHeadBreadCrumb(string title)
        {
            Items =
                new List<BreadCrumbItem>
                    {
                        new BreadCrumbItem {Text = "Hem", Url = "/Home"},
                        new BreadCrumbItem {Text = "Affärsidéer", Url = "/Idea/List"},
                        new BreadCrumbItem {Text = "Branscher", Url = "/Sni/ListHead"},
                        new BreadCrumbItem {Text = title, IsLast = true}
                    };
        }
    }
}