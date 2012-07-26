using System;
using System.Collections.Generic;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Users.AggregateRoots
{
    public interface IUser
    {
        Guid UserId { get; set; }
        string Name { get; set; }
        string CVFileName { get; set; }
        bool Active { get; set; }
        string UserTypeDescription { get; set; }
        Address Address { get; set; }
        Settings Settings { get; set; }
        string Email { get; set; }
        //SniCategory Category { get; set; }
        int UserType { get; set; }
        IEnumerable<string> Urls { get; set; }
        IEnumerable<Idea> Ideas { get; set; }
        //IEnumerable<Bookmark> Bookmarks { get; set; }
        //IEnumerable<Comment> Comments { get; set; }
        IEnumerable<string> Competences { get; set; }
        IEnumerable<Question> GetQuestions(UserModel userModel);
        bool HasImage { get; set; }
        string Presentation { get; set; }
        LookingFor LookingFor { get; set; }
    }
}