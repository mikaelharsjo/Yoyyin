using System;
using System.Collections.Generic;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.Enumerations;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Users.AggregateRoots
{
    public class User : IUser
    {
        public User()
        {
            Ideas = new List<Idea>();
            Urls = new List<string>();
            Competences = new List<string>();
        }

        public Guid id
        {
            get { return UserId; }
            set { UserId = value; }
        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        //byte[] Image { get; set; }
        public string CVFileName { get; set; }
        //string FacebookID { get; set; }
        public bool Active { get; set; }
        public string UserTypeDescription { get; set; }
        
        public string GetDisplayName()
        {
            return Alias ?? Name;
        }

        public DateTime LastLogin { get; set; }
        public string LastLoginFormatted { get; set; }

        public DateTime Created { get; set; }


        public bool HasImage { get; set; }
        public string Email { get; set; }

        public Address Address { get; set; }
        public Settings Settings { get; set; }
        public string Presentation { get; set; }
        public LookingFor LookingFor { get; set; }

        public int UserType { get; set; }
        
        public IEnumerable<string> Urls { get; set; }
        public IEnumerable<Idea> Ideas { get; set; }
        public IEnumerable<string> Competences { get; set; }
        //public IEnumerable<Bookmark> Bookmarks { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }
        //public IEnumerable<Visit> Visits { get; set; }

        public IEnumerable<Question> GetQuestions(UserModel userModel)
        {
            return userModel.QuestionsByUser[UserId];
        }
    }

    public class UserType
    {
        public int UserTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
