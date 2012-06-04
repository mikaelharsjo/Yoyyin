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
using Yoyyin.Model.Users.AggregateRoots;
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
            ViewBag.Title = "Alla affärsidéer";
            return View(_repository
                            .Query(m => m.Users)
                            .OrderBy(u => u.Ideas.First().SniNo)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListBySniNo(string id)
        {
            ViewBag.Title = string.Format("Affärsidéer inom {0}",
                                          _repository.Query(m => m.Snis.First(s => s.SniItem.SniNo == id)).SniItem.Title);
            return View(_repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SniNo == id)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListBySniHead(string id)
        {
            ViewBag.Title = string.Format("Affärsidéer inom {0}",
                                          _repository.Query(m => m.Snis.First(s => s.SniHead.SniHeadId == id)).SniHead.Title);
            return View(_repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SniHeadId == id)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListWantsFinancing()
        {
            ViewBag.Title = "Affärsidéer som söker finansiering";
            return View(_repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SearchProfile.UserTypesNeeded.WantsFinancing())
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult Details(Guid id)
        {
            return View(_userConverter.ConvertToViewModel(_repository
                            .Query(m => m.Users.First(u => u.UserId == id))));
        }
    }
}
