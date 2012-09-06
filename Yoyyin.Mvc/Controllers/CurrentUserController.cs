using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using Yoyyin.Model.Extensions;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Commands;
using Yoyyin.Mvc.ViewModels.Presenters;
using CurrentUserService = Yoyyin.Mvc.Services.CurrentUserService;

namespace Yoyyin.Mvc.Controllers
{
    public class CurrentUserController : Controller
    {
        private readonly CurrentUserService _currentUserService;
        private readonly CurrentUserConverter _converter;
        private readonly IUserRepository _repository;

        public CurrentUserController(CurrentUserService currentUserService, CurrentUserConverter converter, IUserRepository repository)
        {
            _currentUserService = currentUserService;
            _converter = converter;
            _repository = repository;
        }

        [GET("CurrentUser")] 
        public ActionResult Get()
        {
            //return Json(_converter.Convert(_currentUserService.Get()), JsonRequestBehavior.AllowGet);
            var currUser = _currentUserService.Get();
            currUser.LastLoginFormatted = currUser.LastLogin.ToFormattedString();
            return Json(_currentUserService.Get(), JsonRequestBehavior.AllowGet);
        }

        [PUT("CurrentUser/{id}")]
        public ActionResult Update(User user)
        {
            _repository.Execute(new UpdateUserCommand(user));

            return new EmptyResult();
        }
    }
}
