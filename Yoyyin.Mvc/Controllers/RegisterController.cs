using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yoyyin.Mvc.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/

        public ActionResult Step1()
        {
            return PartialView();
        }
    }
}
