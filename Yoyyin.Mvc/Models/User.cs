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
        public string LargeProfileImageMarkup { get; set; }
        public string SniItemTitle { get; set; }
        public string SniHeadTitle { get; set; }
        public string SniNo { get; set; }
        public string SniHeadId { get; set; } 
        public string DetailsHref { get; set; }
        public string UserTypesNeededMarkup { get; set; }
        public string UserTypeMarkup { get; set; }
        public string CompetencesNeededmarkup { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 

        public User(string[] snis)
        {
            SniHeadTitle = snis[0];
            SniItemTitle = snis[1];
            SniNo = snis[2];
            SniHeadId = snis[3];
        }
    }
}