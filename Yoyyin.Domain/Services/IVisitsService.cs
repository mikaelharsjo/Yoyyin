using System;
using System.Collections.Generic;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;

namespace Yoyyin.Domain.Services
{
    public interface IVisitsService
    {
        IEnumerable<IVisit> GetVisits(Guid userID);
        void LogMemberVisit(Guid visitingUserID, Guid userID);
        void LogAnonymousVisit(Guid userID);
    }
}