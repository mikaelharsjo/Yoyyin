using System.Collections.Generic;

namespace Yoyyin.Mvc.ViewModels.BreadCrumb
{
    public interface IBreadCrumb
    {
        IEnumerable<BreadCrumbItem> Items { get;}
        string GetMarkup();
    }
}