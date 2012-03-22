using System;
using System.Collections.Generic;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public interface IVisitsService
    {
        IEnumerable<UserVisits> GetVisits(Guid userID);
        void LogMemberVisit(Guid visitingUserID, Guid userID);
        void LogAnonymousVisit(Guid userID);
    }
}