using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FizzWare.NBuilder;
using Yoyyin.Model;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Mvc.Models;
using Yoyyin.Model.Users.AggregateRoots;
using User = Yoyyin.Model.Users.AggregateRoots.User;

namespace Yoyyin.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserConverter _userConverter;

        public UserController(UserConverter userConverter)
        {
            _userConverter = userConverter;
        }

        public UserController(IUserRepository repository, UserConverter userConverter)
        {
            _repository = repository;
            _userConverter = userConverter;
        }

        public ActionResult List()
        {
            return View(_repository
                            .Query(m => m.Users)
                            .OrderBy(u => u.Ideas.First().SniNo)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListBySniNo(string sniNo)
        {
            return View(_repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SniNo == sniNo)
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        public ActionResult ListWantsFinancing()
        {
            return View(_repository
                            .Query(m => m.Users)
                            .Where(u => u.Ideas.First().SearchProfile.UserTypesNeeded.WantsFinancing())
                            .Select(u => _userConverter.ConvertToViewModel(u)));
        }

        //public ActionResult ListBySni(string sniNo)
        //{
        //    // TODO: Store sniHeadId on user to avoid
        //    //Sni sni = _repository.Query(m => m.Snis).First(s => s.SniItem.SniNo == sniNo);
        //    //var sniChildren = _repository.Query(m => m.Snis).Where(s => s.SniHead.SniHeadId == sni.SniHead.SniHeadId);
            
        //    //return View(_repository
        //    //                .Query(m => m.Users)
        //    //                .Where(u => sniChildren.Contains(u.Ideas.First().SniNo))
        //    //                .Select(u => _userConverter.ConvertToViewModel(u)));
        //}

        public ActionResult Get(Guid userId)
        {
            return View(_repository.Query(m => m.Users.First(u => u.UserId == userId)));
        }
    }
}
