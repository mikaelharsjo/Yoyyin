using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FizzWare.NBuilder;
using Kiwi.Prevalence;
using Yoyyin.Model;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Mvc.Models;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Mvc.Models.BreadCrumb;
using Yoyyin.Mvc.Models.Converters;
using User = Yoyyin.Model.Users.AggregateRoots.User;
using Yoyyin.Model.Users.Enumerations;

namespace Yoyyin.Mvc.Controllers
{
    public class IdeaController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserConverter _userConverter;

        public IdeaController(UserConverter userConverter)
        {
            _userConverter = userConverter;
        }

        public IdeaController(IUserRepository repository, UserConverter userConverter)
        {
            _repository = repository;
            _userConverter = userConverter;
        }

        public ActionResult ListStacked()
        {
            return View(_repository
                .Query(m => m.Users)
                .Take(8)
                .OrderBy(u => u.Ideas.First().SniNo)
                .Select(_userConverter.ConvertToViewModel));
        }

        public ActionResult All()
        {
            return Json(_repository
                            .Query(m => m.Users)
                            .Select(_userConverter.Convert), JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            ViewBag.Title = "Alla affärsidéer";
            ViewBag.SubTitle = "Här visas alla affärsidéer, sorterade på bransch";
            ViewBag.BreadCrumb = new ListBreadCrumb();

            return View(_repository
                            .Query(m => m.Users)
                            .OrderBy(u => u.Ideas.First().SniNo)
                            .Select(_userConverter.ConvertToViewModel));
        }

        public ActionResult ListBySniNo(string id)
        {
            var sniHead = _repository
                            .Query(m => m.SniHeads.Where(head => head.Items.Any(item => item.SniNo == id)))
                            .First();
            ViewBag.Title = "Affärsidéer";
            ViewBag.SubTitle = "Här visas affärsidéer inom " + sniHead.Items.First().Title;
            ViewBag.BreadCrumb = new ListBySniNoBreadCrumb(sniHead);

            return View("List", _repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.Any(idea => idea.SniNo == id))
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListBySniHead(string id)
        {
            string title = _repository.Query(m => m.SniHeads.First(s => s.SniHeadId == id)).Title;
            ViewBag.Title = "Affärsidéer"; // string.Format("Affärsidéer inom {0}", title);
            ViewBag.SubTitle = string.Format("Här visas alla affärsidéer inom {0}", title);
            ViewBag.BreadCrumb = new ListBySniHeadBreadCrumb(title);
                                     
            return View(_repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SniHeadId == id)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListWantsFinancing()
        {
            ViewBag.Title = "Affärsidéer som söker finansiering";
            ViewBag.BreadCrumb = new BreadCrumb
            {
                Items =
                    new List<BreadCrumbItem>
                                                 {
                                                     new BreadCrumbItem {Text = "Hem", Url = "/Home"},
                                                     new BreadCrumbItem {Text = "Affärsidéer"},
                                                     new BreadCrumbItem { Text = "Söker finansiering", IsLast = true }
                                                 }
            };

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
                            .Where(u => u.Competences.Contains(id))
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }
    }
}
