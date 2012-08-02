using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yoyyin.Mvc.Models
{
    public class Comment
    {
        //public Guid UserId { get; set; }
        
        public string Text { get; set; }
        public string Created { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public string UserDisplayName { get; set; }
        public string UserImageSrc { get; set; }
    }
}