using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yoyyin.Mvc.Models
{
    public class Message
    {
        public string DisplayName { get; set; }
        public Guid UserId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Created { get; set; }
        public string ImageSrc { get; set; }
    }
}