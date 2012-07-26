using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yoyyin.Mvc.Controllers
{
    public class MemberController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = string.Format("Välkommen {0}", @User.Identity.Name);
            return View();
        }
    }
}
