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
        public string SmallProfileImageMarkup { get; set; }
        public string SniItemTitle { get; set; }
        public string SniHeadTitle { get; set; }

        public User(string[] snis)
        {
            SniHeadTitle = snis[0];
            SniItemTitle = snis[1];
        }
    }

    

}