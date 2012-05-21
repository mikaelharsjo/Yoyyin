using System;

namespace Yoyyin.Model.Users.Entities
{
    public interface IAnswer
    {
        Guid UserId { get; set; }
        string Text { get; set; }
    }
}