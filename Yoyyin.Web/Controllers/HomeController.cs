using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yoyyin.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {   
            Response.Redirect("~/Home.aspx");
            
            return new EmptyResult();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
