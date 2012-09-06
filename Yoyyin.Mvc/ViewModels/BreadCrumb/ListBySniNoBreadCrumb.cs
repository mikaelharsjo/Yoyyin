using System.Collections.Generic;
using System.Linq;
using Yoyyin.Mvc.ViewModels.BreadCrumb;

namespace Yoyyin.Mvc.ViewModels.BreadCrumb
{
    public class ListBySniNoBreadCrumb : BreadCrumb
    {
        public ListBySniNoBreadCrumb(Model.Users.ValueObjects.SniHead sniHead)
        {
            Items =
                new List<BreadCrumbItem>
                    {
                        new BreadCrumbItem {Text = "Hem", Url = "/Home"},
                        new BreadCrumbItem {Text = "Affärsidéer", Url = "/Idea/List"},
                        new BreadCrumbItem
                            {
                                Text = "Branscher",
                                Url = "/Sni/ListHead"
                            },
                        new BreadCrumbItem
                            {
                                Text = sniHead.Title,
                                Url = "/User/ListBySniHead/" + sniHead.SniHeadId
                            },
                        new BreadCrumbItem
                            {
                                Text = sniHead.Items.First().Title,
                                Url = ""
                            }
                    };
        }
    }
}