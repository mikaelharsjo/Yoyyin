using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Mvc.ViewModels.Presenters;

namespace Yoyyin.Mvc.Controllers
{
    public class MessagesController : Controller
    {
        private readonly MessageConverter _converter;

        public MessagesController(MessageConverter converter)
        {
            _converter = converter;
        }

        public ActionResult GetAll()
        {
            List<Message> messages = new List<Message>
                                         {
                                             new Message
                                                 {
                                                     Created = DateTime.Now,
                                                     Subject = "Ämne",
                                                     Text = "Lorem ipsum",
                                                     UserId = new Guid("dbcadd98e906415da469509b977460ce")
                                                 },
                                             new Message
                                                 {
                                                     Created = DateTime.Now,
                                                     Subject = "test2",
                                                     Text = "testext",
                                                     UserId = new Guid("29f3f948-5266-47ed-9989-98aa6bfb812c")
                                                 }
                                         };
            //return new ContentResult {Content = messages, ContentType = "application/json"};
            //Response.ContentType = "application/json"; 
            return Json(messages.Select(_converter.Convert), JsonRequestBehavior.AllowGet);
        }
    }
}
