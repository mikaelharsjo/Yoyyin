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
using Yoyyin.Mvc.ViewModels.BreadCrumb;
using Yoyyin.Mvc.ViewModels.Presenters;
using User = Yoyyin.Model.Users.AggregateRoots.User;
using Yoyyin.Model.Users.Enumerations;

namespace Yoyyin.Mvc.Controllers
{
    public class IdeaController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserPresenter _userConverter;

        public IdeaController(UserPresenter userConverter)
        {
            _userConverter = userConverter;
        }

        public IdeaController(IUserRepository repository, UserPresenter userConverter)
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
                .Select(_userConverter.Present));
        }

        public ActionResult All()
        {
            return Json(_repository
                            .Query(m => m.Users)
                            .Select(_userConverter.Present), JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            ViewBag.Title = "Alla affärsidéer";
            ViewBag.SubTitle = "Här visas alla affärsidéer, sorterade på bransch";
            ViewBag.BreadCrumb = new ListBreadCrumb();

            return View(_repository
                            .Query(m => m.Users)
                            .OrderBy(u => u.Ideas.First().SniNo)
                            .Select(_userConverter.Present));
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
                            .Select(u => _userConverter.Present(u)));
        }

        public ActionResult ListBySniHead(string id)
        {
            string title = _repository.Query(m => m.SniHeads.First(s => s.SniHeadId == id)).Title;
            ViewBag.Title = "Affärsidéer";
            ViewBag.SubTitle = string.Format("Här visas alla affärsidéer inom {0}", title);
            ViewBag.BreadCrumb = new ListBySniHeadBreadCrumb(title);
                                     
            return View(_repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SniHeadId == id)
                            .Select(u => _userConverter.Present(u)));
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
                            .Where(u => u.Ideas.First().Funding.WantsFinancing)
                            .Select(u => _userConverter.Present(u)));
        }

        public ActionResult ListNeedsCompetence(string id)
        {
            string competence = id;
            ViewBag.Title = "Affärsidéer";
            ViewBag.SubTitle = string.Format("som saknar {0}", competence);
            return View("List", _repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.SelectMany(i => i.SearchProfile.CompetencesNeeded).Contains(competence))          //Competences.Contains(id))
                            .Select(u => _userConverter.Present(u)));
        }
    }
}
