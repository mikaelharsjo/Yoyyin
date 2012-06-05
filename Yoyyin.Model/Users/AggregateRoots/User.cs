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
        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        //byte[] Image { get; set; }
        public string CVFileName { get; set; }
        //string FacebookID { get; set; }
        public bool Active { get; set; }
        public string UserTypeDescription { get; set; }
        public string DisplayName { get; set; }
        public bool HasImage { get; set; }

        public Address Address { get; set; }
        public Settings Settings { get; set; }
        public int UserType { get; set; }
        
        public IEnumerable<string> Urls { get; set; }
        public IEnumerable<Idea> Ideas { get; set; }
        //public IEnumerable<Bookmark> Bookmarks { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }
        //public IEnumerable<Visit> Visits { get; set; }

        public IEnumerable<Question> GetQuestions(UserModel userModel)
        {
            return userModel.QuestionsByUser[UserId];
        }

        public string GetUserTypeTitle()
        {
            UserTypes type = (UserTypes) Enum.Parse(typeof (UserTypes), UserType.ToString());
            // TODO: refactor http://www.rosscode.com/blog/index.php?title=code_smell_switch_statements&more=1&c=1&tb=1&pb=1
            switch (type)
            {
                case UserTypes.Innovator:
                    return "Innovatör/Uppfinnare";
                case UserTypes.Entrepreneur:
                    return "Företagare/Entreprenör";
                case UserTypes.Investor:
                    return "Finansiär";
                case UserTypes.Businessman:
                    return "Företagare";
                case UserTypes.Retiring:
                    return "Företagare";
                case UserTypes.Financing:
                    return "Finansiär/Drake/Ängel";
                default:
                    return "Detta borde aldrig hända";
            }
        }
    }
}
