using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.ValueObjects;
using Yoyyin.Mvc.Models;

namespace Yoyyin.Mvc.Controllers
{
    public class SniController : Controller
    {
        private readonly IUserRepository _userRepository;
        private SniConverter _converter;

        public SniController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _converter = new SniConverter();
        }

        public ActionResult ListHead()
        {
            return View(_userRepository
                            .Query(m => m.SniHeads)
                            .Select(_converter.ConvertToVewModel)
                            .ToList());

        }

        public ActionResult ListItems(string id)
        {
            return View(_userRepository
                            .Query(m => m.SniHeads)
                            .First(h => h.SniHeadId == id)
                            .Items
                            .Select(_converter.ConvertToVewModel)
                            .ToList());
        }

        [GET("SniHeads")]
        public ActionResult Heads()
        {
            return Json(_userRepository.Query(m => m.SniHeads), JsonRequestBehavior.AllowGet);            
        }
    }
}
