using System;

namespace Yoyyin.Domain.Users
{
    public interface ICurrentUser
    {
        Guid UserId { get; set; }
    }
}