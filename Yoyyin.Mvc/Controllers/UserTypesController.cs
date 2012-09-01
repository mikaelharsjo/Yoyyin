using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Commands;
 

namespace Yoyyin.Mvc.Controllers
{
    public class UserTypesController : Controller
    {
        private IUserRepository _repository;

        public UserTypesController(IUserRepository repository)
        {
            _repository = repository;
        }

        [GET("UserTypes")]
        public ActionResult All()
        {
            return Json(_repository.Query(m => m.UserTypes), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(UserType userType)
        {
            int maxId = _repository.Query(m => m.UserTypes.Max(u => u.UserTypeId));
            userType.UserTypeId = maxId + 1;

            _repository.Execute(new AddUserTypeCommand(userType));
            return new EmptyResult();
        }    
    }
}
