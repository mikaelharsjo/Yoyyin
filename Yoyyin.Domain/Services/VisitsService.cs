using System;
using System.Collections.Generic;
using System.Linq;
using Yoyyin.Data;

namespace Yoyyin.Domain.Services
{
    public class VisitsService : IVisitsService
    {
        private readonly EntityUserVisitsRepository _repository;
        private IUserService _userService;

        public VisitsService(EntityUserVisitsRepository repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public IEnumerable<Visit> GetVisits(Guid userID)
        {
            return _repository
                .Find()
                .Where(visit => visit.UserId == userID)
                .OrderByDescending(visit => visit.TimeStamp)
                .Select(CreateVisit);
        }

        public Visit CreateVisit(UserVisits visits)
        {
            return new Visit { VisitingUser = visits.VisitingUserId != null ?  _userService.GetUser((Guid)visits.VisitingUserId) : new AnonymousVisitor()};
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

    public class AnonymousVisitor : User
    {
    }

    public class Visit
    {
        public IUser VisitingUser { get; set; }
    }
}