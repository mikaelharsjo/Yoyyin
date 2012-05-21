using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace $rootnamespace$.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC, upgraded with a NuGet package in a totally unsupported way by Hanselman! No warranty!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
