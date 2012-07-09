using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Tagging;
using Yoyyin.Model.Users;

namespace Yoyyin.Mvc.Controllers
{
    public class TaggingController : Controller
    {
        private IUserRepository userRepository;

        public TaggingController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult ListCompetences()
        {
            var allCompetences = userRepository
                .Query(m => m.Users.Select(u => u.Ideas.First().SearchProfile.Competences));

            WeightedTags tags = new WeightedTags();
            tags.Add(allCompetences);

            return View(tags);
        }

        public ActionResult Competences()
        {
            var allCompetences = userRepository
                                .Query(m => m.Users.Select(u => u.Ideas.First().SearchProfile.Competences));

            return Json(allCompetences, JsonRequestBehavior.AllowGet);
        }
    }
}
