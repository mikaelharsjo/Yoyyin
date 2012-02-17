using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;
using Yoyyin.Domain.Mappers;

namespace Yoyyin.Domain.Services
{
    public class VisitsService : IVisitsService
    {
        private readonly IVisitsRepository _repository;
        private readonly IVisitMapper _mapper;

        public VisitsService(IVisitsRepository repository, IVisitMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Visit> GetVisits(Guid userID)
        {
            return _repository
                .Find()
                .Where(visit => visit.UserId == userID)
                .OrderByDescending(visit => visit.TimeStamp)
                .Select(_mapper.MapVisit);
        }

        public void LogMemberVisit(Guid visitingUserID, Guid userID)
        {
            if (visitingUserID == userID)
                return;

            var visit = _repository
                .Find()
                .FirstOrDefault(x => x.VisitingUserId == visitingUserID && x.UserId == userID);

            if (visit == null) // first time
            {
                visit = new UserVisits { UserId = userID, VisitingUserId = visitingUserID };
                _repository.Add(visit);
            }

            visit.TimeStamp = DateTime.Now;
            _repository.Save();
        }

        public void LogAnonymousVisit(Guid userID)
        {
            UserVisits visit = _repository
                .Find()
                .FirstOrDefault(x => x.VisitingUserId == null && x.UserId == userID);
            if (visit == null)
            {
                visit = new UserVisits();
                _repository.Add(visit);
            }
            visit.VisitingUserId = null;
            visit.UserId = userID;

            visit.TimeStamp = DateTime.Now;
            _repository.Save();
        }
    }
}