using System;
using System.Collections.Generic;
using System.Web;
using Yoyyin.Model.Users.Entities;

namespace Yoyyin.Mvc.Models
{
    public class User
    {
        public string DisplayName { get; set; }
        public Idea FirstIdea { get; set; }
        public string ProfileImageMarkup { get; set; }
    }
}