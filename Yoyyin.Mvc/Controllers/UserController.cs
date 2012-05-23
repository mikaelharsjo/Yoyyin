using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FizzWare.NBuilder;
using Yoyyin.Model;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Mvc.Models;
using User = Yoyyin.Model.Users.AggregateRoots.User;

namespace Yoyyin.Mvc.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _repository;
        private UserConverter _userConverter;

        public UserController()
        {
            _userConverter = new UserConverter();
        }

        public UserController(IUserRepository repository)
        {
            _repository = repository;
            _userConverter = new UserConverter();
        }

        public ActionResult List()
        {
            return View(_repository.Query(m => m.Users).Select(u => _userConverter.ConvertToViewModel(u)));
        }

        private User ConvertToViewModel(User priav)
        {
            throw new NotImplementedException();
        }

        public ActionResult Get(Guid userId)
        {
            return View(_repository.Query(m => m.Users.First(u => u.UserId == userId)));
        }
    }
}
