using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.ValueObjects;

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
            return
                View(
                    _userRepository.Query(m => m.Snis).GroupBy(k => k.SniHead.SniHeadId).Select(
                        g => g.First(s => s.SniHead.SniHeadId == g.Key)).ToList());
        }
    }
}
