using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Users;

namespace Yoyyin.Mvc.Controllers
{
    public class MatchingController : Controller
    {
        private IUserRepository _userRepository;

        public MatchingController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult GetQuickSearchTypeAheadItems()
        {
            // TODO: move to class
            List<string> words = new List<string>();
            var competences = _userRepository
                .Query(m => m.Users.Select(u => u.Ideas.First().SearchProfile.Competences));

            var searchWords = _userRepository
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
