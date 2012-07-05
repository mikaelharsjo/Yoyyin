using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Users;

namespace Yoyyin.Mvc.Controllers
{
    public class UserTypeController : Controller
    {
        private IUserRepository _repository;

        public UserTypeController(IUserRepository repository)
        {
            _repository = repository;
        }

        public ActionResult All()
        {
            return Json(_repository.Query(m => m.UserTypes), JsonRequestBehavior.AllowGet);
        }
    }
}
