using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FizzWare.NBuilder;
using Yoyyin.Model;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Entities;

namespace Yoyyin.Mvc.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _repository;

        public UserController()
        {
        }

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        public ActionResult List()
        {
            //var users = Builder<User>
            //    .CreateListOfSize(1000)
            //    .Build();

            //foreach (User user in users)
            //{
            //    user.Ideas =
            //        new List<Idea>
            //            {
            //                new Idea
            //                    {
            //                        Title = "Min affärsidé",
            //                        Description =
            //                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis leo neque, tempus nec pulvinar commodo, pretium ac erat. Etiam auctor, dolor vehicula feugiat volutpat, lorem massa gravida nisi, in consectetur mauris orci tempor enim. Nullam accumsan ultricies sollicitudin"
            //                    }
            //            };
            //}

            //return View(users);

            return View(_repository.Query(m => m.Users));
        }

        public ActionResult Get(Guid userId)
        {
            return View(_repository.Query(m => m.Users.First(u => u.UserId == userId)));
        }
    }
}
