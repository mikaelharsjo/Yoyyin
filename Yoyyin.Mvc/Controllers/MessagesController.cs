using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Mvc.Controllers
{
    public class MessagesController : Controller
    {
        public ActionResult GetAll()
        {
            List<Message> messages = new List<Message>
                                         {
                                             new Message {Created = DateTime.Now, Subject = "test", Text = "Lorem ipsum"},
                                             new Message {Created = DateTime.Now, Subject = "test2", Text = "testext"}
                                         };
            //return new ContentResult {Content = messages, ContentType = "application/json"};
            //Response.ContentType = "application/json"; 
            return Json(messages, JsonRequestBehavior.AllowGet);
        }
    }
}
