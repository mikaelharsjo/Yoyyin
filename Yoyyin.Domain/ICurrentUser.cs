using System;

namespace Yoyyin.Domain
{
    public interface ICurrentUser
    {
        Guid UserId { get; set; }
    }
}