using System;
using System.Linq;
using System.Text;
using Yoyyin.Model.Matching.MatchResult;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Entities;
using Yoyyin.Model.Users.Enumerations;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Matching
{
    public class Matcher
    {
        private IUser _firstUser;
        private IUser _secondUser;

        public Matcher(User firstUser, User secondUser)
        {
            _firstUser = firstUser;
            _secondUser = secondUser;
        }

        public IMatchResult MatchLookingFor()
        {
            return _firstUser.LookingFor.MatchWith(_secondUser.LookingFor) ? new LookingForMatch() : new DoesNotMatch() as IMatchResult;
        }

        public IMatchResult MatchUserType()
        {
            var secondUserTypesFlattened = _secondUser
                .Ideas
                .SelectMany(idea => idea.SearchProfile.UserTypesNeeded.UserTypeIds);
                       
                       
            return secondUserTypesFlattened.Any(secondUserType => secondUserType == _firstUser.UserType)
                       ? new UserTypeMatch(_firstUser.UserType, secondUserTypesFlattened)
                       : new DoesNotMatch() as IMatchResult;
        }

        public IMatchResult MatchUserTypesNeeded()
        {
            var userTypesFlattened = _firstUser
                .Ideas
                .SelectMany(idea => idea.SearchProfile.UserTypesNeeded.UserTypeIds);

            return userTypesFlattened.Any(neededUserType => _secondUser.UserType == neededUserType)
                       ? new UserTypeNeededMatch(userTypesFlattened, _secondUser.UserType)
                       : new DoesNotMatch() as IMatchResult;
        }

        public IMatchResult MatchCompetencesNeeded()
        {
            var neededCompetencesFlattened = _firstUser
                                                .Ideas
                                                .SelectMany(idea => idea.SearchProfile.CompetencesNeeded);

            return neededCompetencesFlattened.Any(competence => _secondUser.Competences.Contains(competence))
                       ? new CompetencesNeededMatch(neededCompetencesFlattened, _secondUser.Competences)
                       : new DoesNotMatch() as IMatchResult;
        }
    }
}