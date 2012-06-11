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
using Yoyyin.Model.Users.Enumerations;

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
            ViewBag.BreadCrumb = new BreadCrumb()
                                     {
                                         Items =
                                             new List<BreadCrumbItem>
                                                 {
                                                     new BreadCrumbItem {Text = "Affärsidéer", Url = ""},
                                                     new BreadCrumbItem
                                                         {
                                                             Text = "Alla",
                                                             Url = "/User/List"
                                                         }
                                                 }
                                     };
            return View(_repository
                            .Query(m => m.Users)
                            .OrderBy(u => u.Ideas.First().SniNo)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListBySniNo(string id)
        {
            var sni = _repository.Query(m => m.Snis.First(s => s.SniItem.SniNo == id));
            ViewBag.Title = string.Format("Affärsidéer inom {0}", sni != null ? sni.SniItem.Title: "");
            return View("List", _repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SniNo == id)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListBySniHead(string id)
        {
            string title = _repository.Query(m => m.Snis.First(s => s.SniHead.SniHeadId == id)).SniHead.Title;
            ViewBag.Title = string.Format("Affärsidéer inom {0}", title);
            ViewBag.BreadCrumb = new BreadCrumb()
                                     {
                                         Items =
                                             new List<BreadCrumbItem>
                                                 {
                                                     new BreadCrumbItem {Text = "Affärsidéer", Url = ""},
                                                     new BreadCrumbItem
                                                         {
                                                             Text = "Kompetenser",
                                                             Url = "/User/List"
                                                         },
                                                     new BreadCrumbItem
                                                         {
                                                             Text = title,
                                                             Url = ""
                                                         }
                                                 }
                                     };
            return View(_repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SniHeadId == id)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListWantsFinancing()
        {
            ViewBag.Title = "Affärsidéer som söker finansiering";
            return View("List", _repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SearchProfile.UserTypesNeeded.WantsFinancing())
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListByUserType(int userType, string title)
        {
            //UserTypes type = (UserTypes)Enum.Parse(typeof(UserTypes), userType.ToString());
            ViewBag.Title = string.Format("Affärspartners som är {0}", title);
            return View("List", _repository
                            .Query(m => m.Users)
                            .Where(u => u.UserType == userType)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListByCompetence(string id)
        {
            string competence = id;
            ViewBag.Title = string.Format("Affärspartners som kan {0}", competence);
            return View("List", _repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SearchProfile.Competences.Contains(id))
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult QuickSearch(string term)
        {
            ViewBag.BreadCrumb = new NoBreadCrumb();
            return View("List", _repository
                                    .Query(m => m.Users)
                                    .Where(u => u.Ideas.First().SearchProfile.ContainsString(term.ToLower()))
                                    .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult Details(Guid id)
        {
            var user = _userConverter.ConvertToViewModel(_repository
                                                             .Query(m => m.Users.First(u => u.UserId == id)));
            ViewBag.Title = user.FirstIdea.Title;
            return View(user);
        }
    }
}
