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
        private readonly IUserRepository _repository;
        private readonly UserConverter _userConverter;

        public UserController(UserConverter userConverter)
        {
            _userConverter = userConverter;
        }

        public UserController(IUserRepository repository, UserConverter userConverter)
        {
            _repository = repository;
            _userConverter = userConverter;
        }

        public ActionResult List()
        {
            return View(_repository.Query(m => m.Users).Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult Get(Guid userId)
        {
            return View(_repository.Query(m => m.Users.First(u => u.UserId == userId)));
        }
    }
}
