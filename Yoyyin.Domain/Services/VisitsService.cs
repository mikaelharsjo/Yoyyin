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
        private readonly IVisitRepository _visitRepository;
        private IUserRepository _userRepository;

        public VisitsService(IVisitRepository visitRepository, IUserRepository userRepository)
        {
            _visitRepository = visitRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<IVisit> GetVisits(Guid userID)
        {
            return _visitRepository
                .Find(visit => visit.UserId == userID)
                .OrderByDescending(visit => visit.Created);
        }

        public void LogMemberVisit(Guid visitingUserID, Guid userID)
        {
            if (visitingUserID == userID)
                return;

            var visit = _visitRepository
                .FindAll()
                .FirstOrDefault(x => x.VisitingUserId == visitingUserID && x.UserId == userID);

            if (visit == null) // first time
            {
                visit = new Visit { UserId = userID, VisitingUserId = visitingUserID };
                _visitRepository.Add(visit);
            }

            visit.Created = DateTime.Now;
            //_repository.Save();
        }

        public void LogAnonymousVisit(Guid userID)
        {
            var visit = _visitRepository
                .Find(x => x.VisitingUserId == null && x.UserId == userID)
                .FirstOrDefault();
            if (visit == null)
            {
                visit = new Visit();
                _visitRepository.Add(visit);
            }
            visit.VisitingUserId = null;
            visit.UserId = userID;

            visit.Created = DateTime.Now;
            //_repository.Save();
        }

        public IEnumerable<IUser> GetUsersWithMostVisits()
        {
            return _visitRepository.FindAll().GroupBy(v => v.User1).OrderBy(g => g.Count()).Select(g => g.Key);
        }
    }
}