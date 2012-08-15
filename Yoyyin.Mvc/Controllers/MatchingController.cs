using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Yoyyin.Model.Matching;
using Yoyyin.Model.Users;
using Yoyyin.Mvc.Models.Presenters;
using Yoyyin.Mvc.Services;

namespace Yoyyin.Mvc.Controllers
{
    public class MatchingController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly CurrentUserService _currentUserService;
        private readonly UserConverter _converter;

        public MatchingController(IUserRepository repository, CurrentUserService currentUserService, UserConverter converter)
        {
            _repository = repository;
            _currentUserService = currentUserService;
            _converter = converter;
        }

        public ActionResult Single(Guid id)
        {
            var currentUser = _currentUserService.Get();
            var userToMatchWith = _repository.Query(m => m.Users.First(u => u.UserId == id));
            var matcher = new Matcher(currentUser, userToMatchWith, _repository);
            var matchResult = matcher.Match();

            return Json(new
                        {
                            matchResult,
                            currentUser = _converter.Convert(currentUser),
                            userToMatchWith = _converter.Convert(userToMatchWith)
                        }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetQuickSearchTypeAheadItems()
        {
            // TODO: move to class
            HashSet<string> words = new HashSet<string>();
            var competences = _repository
                .Query(m => m.Users.Select(u => u.Ideas.First().SearchProfile.CompetencesNeeded));

            var searchWords = _repository
                .Query(m => m.Users.Select(u => u.Ideas.First().SearchProfile.SearchWords));

            var concatenated = competences.Concat(searchWords);

            foreach (var array in concatenated)
            {
                foreach (string word in array)
                {
                    words.Add(word);
                }
            }

            return Json(words, JsonRequestBehavior.AllowGet);
        }
    }
}
