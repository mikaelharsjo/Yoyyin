
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Mvc.Models;
using Yoyyin.Mvc.Models.BreadCrumb;
using Yoyyin.Mvc.Models.Converters;
using Comment = Yoyyin.Mvc.Models.Comment;

namespace Yoyyin.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserConverter _userConverter;

        public UserController(IUserRepository repository, UserConverter userConverter)
        {
            _repository = repository;
            _userConverter = userConverter;
        }

        public ActionResult List()
        {
            return View(_repository
                            .Query(m => m.Users)
                            .Select(_userConverter.Convert));
        }

        public ActionResult All()
        {
            return Json(_repository
                            .Query(m => m.Users)
                            .Select(_userConverter.Convert), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(Guid id)
        {
            var user = _repository.Query(m => m.Users.First(u => u.UserId == id));
            user.Ideas.First().Comments = new List<Model.Users.Entities.Comment>
                                              {
                                                  new Model.Users.Entities.Comment
                                                           {
                                                               UserId = new Guid("6e37b452-4f92-45e0-875b-01dd92de7686"),
                                                               Created = DateTime.Now.AddDays(-1),
                                                               Text = "Lorem ipsum dolor cit amet"
                                                           },
                                                           new Model.Users.Entities.Comment
                                                           {
                                                               UserId = new Guid("6e37b452-4f92-45e0-875b-01dd92de7686"),
                                                               Created = DateTime.Now.AddDays(-5),
                                                               Text = "Intressant idé"
                                                           }
                                              };

            return Json(_userConverter.Convert(user), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(Guid id)
        {
            var user = _userConverter.ConvertToViewModel(_repository
                                                             .Query(m => m.Users.First(u => u.UserId == id)));
            ViewBag.BreadCrumb = new BreadCrumb
            {
                Items =
                    new List<BreadCrumbItem>     {
                                                     new BreadCrumbItem {Text = "Hem", Url = "/Home"},
                                                     new BreadCrumbItem {Text = "Affärsidéer", Url = "/User/List"},
                                                     new BreadCrumbItem { Text = user.SniHeadTitle, Url = "/User/ListBySniHead/" + user.SniHeadId},
                                                     new BreadCrumbItem { Text = user.DisplayName, IsLast = true }
                                                 }
            };

            ViewBag.Title = user.FirstIdea.Title;
            return View(user);
        }
    }
}
