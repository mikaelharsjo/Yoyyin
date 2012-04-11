using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.Data.Core.Repositories;

namespace Yoyyin.Domain.Services
{
    public class VisitsService : IVisitsService
    {
        private readonly IRepository<IVisit> _repository;

        public VisitsService(IRepository<IVisit> repository)
        {
            _repository = repository;
        }

        public IEnumerable<IVisit> GetVisits(Guid userID)
        {
            return _repository
                .Find(visit => visit.UserId == userID)
                .OrderByDescending(visit => visit.Created);
        }

        public void LogMemberVisit(Guid visitingUserID, Guid userID)
        {
            if (visitingUserID == userID)
                return;

            var visit = _repository
                .FindAll()
                .FirstOrDefault(x => x.VisitingUserId == visitingUserID && x.UserId == userID);

            if (visit == null) // first time
            {
                visit = new Visit { UserId = userID, VisitingUserId = visitingUserID };
                _repository.Add(visit);
            }

            visit.Created = DateTime.Now;
            //_repository.Save();
        }

        public void LogAnonymousVisit(Guid userID)
        {
            var visit = _repository
                .Find(x => x.VisitingUserId == null && x.UserId == userID)
                .FirstOrDefault();
            if (visit == null)
            {
                visit = new Visit();
                _repository.Add(visit);
            }
            visit.VisitingUserId = null;
            visit.UserId = userID;

            visit.Created = DateTime.Now;
            //_repository.Save();
        }
    }
}