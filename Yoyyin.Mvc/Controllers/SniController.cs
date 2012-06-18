using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.ValueObjects;
using Yoyyin.Mvc.Models;

namespace Yoyyin.Mvc.Controllers
{
    public class SniController : Controller
    {
        private IUserRepository _userRepository;

        public SniController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult ListHead()
        {
            var distinctSniHeads = _userRepository
                                        .Query(m => m.Snis)
                                            .GroupBy(k => k.SniHead.SniHeadId)
                                            .Select(g => g.First(s => s.SniHead.SniHeadId == g.Key));

            var viewModel =
                distinctSniHeads.Select(
                    sh =>
                    new Sni
                        {
                            Title = sh.SniHead.Title,
                            UrlToIdeas = string.Format("/User/ListBySniHead/{0}", sh.SniHead.SniHeadId),
                            UrlToItems = string.Format("/Sni/ListItems/{0}", sh.SniHead.SniHeadId)
                        });
            return View(viewModel.ToList());
        }
    }
}
