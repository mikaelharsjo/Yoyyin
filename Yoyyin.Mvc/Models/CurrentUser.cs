using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Mvc.Models
{
    public class CurrentUser //: Model.Users.AggregateRoots.User
    {
        public bool Active { get; set; }
        public Address Address { get; set; }
        public IEnumerable<string> Competences { get; set; }
        public string CVFileName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public IEnumerable<Model.Users.Entities.Idea> Ideas { get; set; }
        public string Name { get; set; }
        public string SmallProfileImageSrc { get; set; }
        public string UserType { get; set; }
        public string LastLogin { get; set; }
    }
}