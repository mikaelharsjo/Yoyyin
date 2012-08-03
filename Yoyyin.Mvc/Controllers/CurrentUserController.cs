using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Services;
using Yoyyin.Mvc.Models.Converters;
using CurrentUserService = Yoyyin.Mvc.Services.CurrentUserService;

namespace Yoyyin.Mvc.Controllers
{
    public class CurrentUserController : Controller
    {
        private readonly CurrentUserService _currentUserService;
        private readonly CurrentUserConverter _converter;

        public CurrentUserController(CurrentUserService currentUserService, CurrentUserConverter converter)
        {
            _currentUserService = currentUserService;
            _converter = converter;
        }

        public ActionResult Get()
        {
            return Json(_converter.Convert(_currentUserService.Get()), JsonRequestBehavior.AllowGet);
        }
    }
}
