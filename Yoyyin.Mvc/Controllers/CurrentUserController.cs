using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using Yoyyin.Mvc.Models.Presenters;
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

        [GET("CurrentUser")] 
        public ActionResult Get()
        {
            return Json(_converter.Convert(_currentUserService.Get()), JsonRequestBehavior.AllowGet);
        }

        [POST("CurrentUser")]
        public ActionResult Save()
        {
            return new EmptyResult();
        }
    }
}
