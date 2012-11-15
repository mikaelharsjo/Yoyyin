using System;
using System.Collections.Generic;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Users.AggregateRoots
{
    public interface IUser
    {
        string AuthKey { get; set; }
        Guid UserId { get; set; }
        string Name { get; set; }
        string CVFileName { get; set; }
        bool Active { get; set; }
        string UserTypeDescription { get; set; }
        Address Address { get; set; }
        Settings Settings { get; set; }
        string Email { get; set; }
        int UserType { get; set; }
        IEnumerable<string> Urls { get; set; }
        IEnumerable<Idea> Ideas { get; set; }
        IEnumerable<string> Competences { get; set; }
        IEnumerable<Question> GetQuestions(UserModel userModel);

        Image Image { get; set; }
        
        string Presentation { get; set; }
        LookingFor LookingFor { get; set; }
        
        // move?
        DateTime LastLogin { get; set; }
        DateTime Created { get; set; }
        string LastLoginFormatted { get; set; }

        string DisplayName { get; }
    }
}