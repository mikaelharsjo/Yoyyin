using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Yoyyin.Model.Users;
using Yoyyin.Mvc.ViewModels.BreadCrumb;
using Yoyyin.Mvc.ViewModels.Presenters;

namespace Yoyyin.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserPresenter _userPresenter;

        public UserController(IUserRepository repository, UserPresenter userPresenter)
        {
            _repository = repository;
            _userPresenter = userPresenter;
        }

        public ActionResult List()
        {
            return View(_repository
                            .Query(m => m.Users)
                            .Select(_userPresenter.Present));
        }

        public ActionResult ListByUserType(int id)
        {
            var userType = _repository.Query(m => m.UserTypes.First(u => u.UserTypeId == id));
            ViewBag.SubTitle = string.Format("Affärspartners som är {0}", userType.Title.ToLower());
            return View("List", _repository
                            .Query(m => m.Users)
                            .Where(u => u.UserType == id)
                            .Select(u => _userPresenter.Present(u)));
        }

        public ActionResult ListByCompetence(string id)
        {
            string competence = id;
            ViewBag.SubTitle = string.Format("Affärspartners som kan {0}", competence);
            return View("List", _repository
                            .Query(m => m.Users)
                            .Where(u => u.Competences.Contains(id))
                            .Select(u => _userPresenter.Present(u)));
        }

        public ActionResult All()
        {
            return Json(_repository
                            .Query(m => m.Users)
                            .Select(_userPresenter.Present), JsonRequestBehavior.AllowGet);
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

            return Json(_userPresenter.Present(user), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(Guid id)
        {
            var user = _userPresenter.Present(_repository.Query(m => m.Users.First(u => u.UserId == id)));
            ViewBag.BreadCrumb = new BreadCrumb
            {
                Items =
                    new List<BreadCrumbItem>     {
                                                     new BreadCrumbItem {Text = "Hem", Url = "/Home"},
                                                     //new BreadCrumbItem {Text = "Affärsidéer", Url = "/User/List"},
                                                     //new BreadCrumbItem { Text = user.IdeasSniHeadTitle, Url = "/User/ListBySniHead/" + user.SniHeadId},
                                                     new BreadCrumbItem { Text = user.DisplayName, IsLast = true }
                                                 }
            };

            ViewBag.Title = user.Ideas.First().Title;
            return View(user);
        }
    }
}
