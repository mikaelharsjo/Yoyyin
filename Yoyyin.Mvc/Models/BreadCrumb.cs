using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yoyyin.Mvc.Models
{
    public class BreadCrumb
    {
        public IEnumerable<BreadCrumbItem> Items { get; set; }
    }

    public class BreadCrumbItem 
    {
        public string Text { get; set; }
        public string Url { get; set; }
    }
}