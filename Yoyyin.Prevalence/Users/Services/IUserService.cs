using System;
using System.Collections.Generic;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Users.Services
{
    public interface IUserService
    {
        IEnumerable<Question> GetQuestions(Guid userId);
    }
}