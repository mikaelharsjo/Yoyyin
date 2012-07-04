using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Users;
using Yoyyin.Mvc.Models;
using Yoyyin.Mvc.Models.BreadCrumb;

namespace Yoyyin.Mvc.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserConverter _userConverter;

        public SearchController(IUserRepository repository, UserConverter userConverter)
        {
            _repository = repository;
            _userConverter = userConverter;
        }

        public ActionResult Quick(string term)
        {
            var users = GetUsersByTerm(term);
            ViewBag.BreadCrumb = new NoBreadCrumb();
            ViewBag.ResultText = string.Format("<strong>Resultat för {0}</strong>, {1} träffar", term, users.Count());
            return PartialView("QuickSearch", users);
        }

        public ActionResult QuickJson(string term)
        {
            return Json(GetUsersByTerm(term), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Models.User> GetUsersByTerm(string term)
        {
            var users = _repository
                .Query(m => m.Users)
                .Where(u => u.Ideas.First().SearchProfile.ContainsString(term.ToLower()))
                .Select(u => _userConverter.ConvertToViewModel(u));
            return users;
        }

    }
}
