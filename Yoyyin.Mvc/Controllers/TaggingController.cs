using System.Linq;
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
            return View(GetWeightedCompetences());
        }

        public ActionResult ListCompetencesNeeded()
        {
            return View(GetWeightedCompetencesNeeded());
        }

        public ActionResult CompetencesPartial()
        {
            return PartialView(GetWeightedCompetences());
        }

        private WeightedTags GetWeightedCompetences()
        {
            // TODO: include CompetencesNeeded?
            var allCompetences = userRepository
                .Query(m => m.Users.Select(u => u.Competences));

            WeightedTags tags = new WeightedTags();
            tags.Add(allCompetences);
            return tags;
        }

        private WeightedTags GetWeightedCompetencesNeeded()
        {
            // TODO: include CompetencesNeeded?
            var allCompetences = userRepository
                .Query(m => m.Users.Select(u => u.Ideas.First().SearchProfile.CompetencesNeeded));

            WeightedTags tags = new WeightedTags();
            tags.Add(allCompetences);
            return tags;
        }

        public ActionResult Competences()
        {
            var allCompetences = userRepository
                                .Query(m => m.Users.Select(u => u.Competences));

            WeightedTags tags = new WeightedTags();
            tags.Add(allCompetences);

            return Json(tags.SortedStrings(), JsonRequestBehavior.AllowGet);
        }
    }
}
