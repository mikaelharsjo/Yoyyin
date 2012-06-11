using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yoyyin.Mvc.Models
{
    public interface IBreadCrumb
    {
        IEnumerable<BreadCrumbItem> Items { get;}
    }

    public class BreadCrumb : IBreadCrumb
    {
        public IEnumerable<BreadCrumbItem> Items { get; set; }
    }

    public class NoBreadCrumb : IBreadCrumb
    {
        public NoBreadCrumb()
        {
            Items = new BreadCrumbItem[0];
        }

        public IEnumerable<BreadCrumbItem> Items { get; private set; }
    }

    public class BreadCrumbItem 
    {
        public string Text { get; set; }
        public string Url { get; set; }
    }
}