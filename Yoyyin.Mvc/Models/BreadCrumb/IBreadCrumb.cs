using System.Collections.Generic;

namespace Yoyyin.Mvc.Models.BreadCrumb
{
    public interface IBreadCrumb
    {
        IEnumerable<BreadCrumbItem> Items { get;}
        string GetMarkup();
    }
}