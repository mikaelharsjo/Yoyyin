using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Mvc.Models;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Mvc.ViewModels.BreadCrumb;
using Yoyyin.Mvc.ViewModels.Presenters;
using User = Yoyyin.Model.Users.AggregateRoots.User;

namespace Yoyyin.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserConverter _userConverter;

        public HomeController(UserConverter userConverter)
        {
            //_repository = repository;
            _userConverter = userConverter;
        }

        public HomeController(IUserRepository repository, UserConverter userConverter)
        {
            _repository = repository;
            _userConverter = userConverter;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Hem";
            return View(_repository
                            .Query(m => m.Users)
                            .Take(12)
                            .OrderBy(u => u.Ideas.First().SniNo)
                            .Select(_userConverter.ConvertToViewModel));
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
