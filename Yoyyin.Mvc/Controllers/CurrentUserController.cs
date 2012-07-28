using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Services;
using CurrentUserService = Yoyyin.Mvc.Services.CurrentUserService;

namespace Yoyyin.Mvc.Controllers
{
    public class CurrentUserController : Controller
    {
        private readonly CurrentUserService _currentUserService;

        public CurrentUserController(CurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public ActionResult Get()
        {
            return Json(_currentUserService.Get(), JsonRequestBehavior.AllowGet);
        }

    }
}
